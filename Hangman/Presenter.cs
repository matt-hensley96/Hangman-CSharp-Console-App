﻿using System;
using System.Text;

namespace Hangman
{
    internal static class Presenter
    {
        public static void Greeting()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            StringBuilder header = new StringBuilder();
            header.Append('-', 8).AppendLine().Append("HANGMAN").AppendLine().Append('-', 8);
            Console.WriteLine(header);
        }

        public static string[] GetPlayerNames()
        {
            string[] playerNames = new string[2];

            Console.WriteLine("Player 1, enter your name, then hit Enter.");
            playerNames[0] = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Player 2, enter your name, then hit Enter.");
            playerNames[1] = Console.ReadLine();

            Console.Clear();
            return playerNames;
        }

        public static string GetSecretWord(string[] playerNames)
        {
            Console.WriteLine();
            Console.WriteLine($"{playerNames[0]}, type a secret word, then hit Enter. It must be one word, containing letters only (less than 10 unique letters).");

            string secretWordInput = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (key.Key != ConsoleKey.Backspace)
                    Console.Write("*");
                secretWordInput += key.KeyChar;
            }

            string secretWord = Validator.ForceUserToGiveValidSecretWord(secretWordInput);
            secretWord = secretWord.ToUpper();
            Console.WriteLine();

            Console.Clear();
            return secretWord;
        }

        public static char[] CreateAnswerPreview(string secretWord)
        {
            char[] answerPreview = new char[secretWord.Length];
            for (int i = 0; i < answerPreview.Length; i++)
            {
                answerPreview[i] = '_';
            }

            return answerPreview;
        }

        public static char[] UpdateAnswerPreview(char guess, string secretWord, char[] answerPreview)
        {
            guess = char.ToUpper(guess);
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == guess)
                    answerPreview[i] = guess;
            }

            return answerPreview;
        }

        public static void AskForGuess(string[] playerNames, int livesRemaining, char[]answerPreview)
        {
            Console.WriteLine();
            Console.WriteLine($"{playerNames[1]}, you have {livesRemaining} lives left. Guess a letter from the secret word");

            Console.WriteLine("So far, you've guessed:");
            for (int i = 0; i < answerPreview.Length; i++)
            {
                Console.Write(answerPreview[i] + " ");
            }
            Console.WriteLine();

            Artist.PaintMan(livesRemaining);
        }

        public static void GiveResults(string[] playerNames, char[] answerPreview, bool playerWon)
        {
            if (playerWon == true)
            {
                Console.WriteLine($"You won {playerNames[1]}! {playerNames[0]}'s word was:");
                Console.WriteLine();
                for (int i = 0; i < answerPreview.Length; i++)
                {
                    Console.Write(answerPreview[i] + " ");
                }
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
    }


}