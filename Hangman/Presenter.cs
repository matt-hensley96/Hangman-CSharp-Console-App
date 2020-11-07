using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    internal static class Presenter
    {
        public static void ShowNameOfGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            var header = new StringBuilder();
            header.Append('-', 8)
                .AppendLine()
                .Append("HANGMAN")
                .AppendLine()
                .Append('-', 8);

            Console.WriteLine(header);
        }

        internal static void SetUpGame()
        {

        }

        public static string[] GetPlayerNames()
        {
            var playerNames = new string[2];

            Console.WriteLine("Player 1, enter your name, then hit Enter.");
            playerNames[0] = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Player 2, enter your name, then hit Enter.");

            playerNames[1] = Console.ReadLine();

            Console.Clear();

            return playerNames;
        }

        public static string GetSecretWord(string playerOne)
        {
            Console.WriteLine($"{playerOne}, type a secret word, then hit Enter. It must be one word, containing " +
                              "letters only (less than 10 unique letters).");

            bool secretWordIsValid = default;
            string secretWordInput = default;

            while (!secretWordIsValid)
            {
                secretWordInput = GetObscuredInput();
                Console.Clear();
                secretWordIsValid = Validator.IsSecretWordValid(secretWordInput);
            }

            return secretWordInput.ToUpper();
        }

        public static char[] GetAnswerPreview(string secretWord)
        {
            var answerPreview = new char[secretWord.Length];

            for (var i = 0; i < answerPreview.Length; i++)
                answerPreview[i] = '_';

            return answerPreview;
        }

        internal static void PresentGame(string[] playerNames, string secretWord, char[] answerPreview)
        {
            var livesRemaining = 8;
            bool playerWon = default;
            var guessesSubmittedSoFar = new List<char>();

            while (livesRemaining > 0 && !playerWon)
            {
                char guess = GetGuess(playerNames, livesRemaining, guessesSubmittedSoFar, answerPreview);
                guessesSubmittedSoFar.Add(char.ToUpper(guess));

                Console.Clear();

                if (!Validator.IsGuessCorrect(secretWord, guess))
                    livesRemaining--;

                UpdateAnswerPreview(guess, secretWord, answerPreview);

                var completedAnswer = new string(answerPreview);

                if (completedAnswer == secretWord)
                    playerWon = true;
            }

            GiveResults(playerNames, answerPreview, playerWon);
        }

        private static void UpdateAnswerPreview(char guess, string secretWord, char[] answerPreview)
        {
            guess = char.ToUpper(guess);

            for (var i = 0; i < secretWord.Length; i++)
                if (secretWord[i] == guess)
                    answerPreview[i] = guess;
        }

        private static char GetGuess(string[] playerNames, int livesRemaining, List<char> guessesSubmittedSoFar, char[] answerPreview)
        {
            Console.WriteLine($"{playerNames[1]}, you have {livesRemaining} lives left. Guess a letter from the secret word");
            Console.WriteLine("So far, you've guessed this much of the word correctly:");

            foreach (char letter in answerPreview)
                Console.Write(letter + " ");

            Console.WriteLine();
            Console.WriteLine("And you've already guessed these letters:");
            foreach (char letter in guessesSubmittedSoFar)
                Console.Write(letter + "");
            Console.WriteLine();

            Console.WriteLine();
            Artist.PaintMan(livesRemaining);

            char guess = default;
            bool guessIsValid = default;

            while (!guessIsValid)
            {
                guess = Console.ReadKey().KeyChar;
                Console.Clear();
                guessIsValid = Validator.IsGuessValid(guess);
            }

            return guess;
        }

        private static void GiveResults(string[] playerNames, char[] answerPreview, bool playerWon)
        {
            if (playerWon)
            {
                Console.WriteLine($"You won {playerNames[1]}! {playerNames[0]}'s word was:");
                Console.WriteLine();

                foreach (char t in answerPreview)
                    Console.Write(t + " ");

                Console.WriteLine();
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine($"GAME OVER!!! You ran out of lives {playerNames[1]}!");
                Console.WriteLine();
                Artist.PaintMan(0);
            }
        }

        private static string GetObscuredInput()
        {
            string secretWordInput = default;
            var userIsStillTyping = true;

            while (userIsStillTyping)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    Console.Write("*");
                    secretWordInput += key.KeyChar;
                }

                if (key.Key == ConsoleKey.Enter)
                    userIsStillTyping = false;
            }

            return secretWordInput;
        }
    }
}