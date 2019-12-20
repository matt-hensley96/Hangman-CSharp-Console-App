﻿using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        // IN PROGRESS: Obscure the letters in the secret word (as the user types them) using * characters (like a password)
        // TO DO: Make a 1-player option?
        {
            Presenter.Greeting();

            // Initialise anything needed later
            int livesRemaining = 8;
            bool playerWon = false;

            // Store the names of the two players
            Console.WriteLine("Player 1, enter your name, then hit Enter.");
            string playerOneName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Player 2, enter your name, then hit Enter.");
            string playerTwoName = Console.ReadLine();

            // Store the secret word
            Console.WriteLine();
            Console.WriteLine($"{playerOneName}, type a secret word, then hit Enter. It must be one word, containing letters only (less than 10).");
            
            
            string secretWordInput = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                Console.Write("*");
                secretWordInput += key.KeyChar;
            }

            string secretWord = Validator.ForceUserToGiveValidSecretWord(secretWordInput);
            secretWord = secretWord.ToUpper();

            // Create an array of dashes, the length of the secret word
            char[] answerPreview = new char[secretWord.Length];
            for (int i = 0; i < answerPreview.Length; i++)
            {
                answerPreview[i] = '_';
            }



            // Main Gameplay:
            while (livesRemaining > 0 && !playerWon)
            {
                // Introduce game:
                Console.WriteLine();
                Console.WriteLine($"{playerTwoName}, you have {livesRemaining} lives left. Guess a letter from the secret word (in upper case)");

                // Write their guess so far:
                Console.WriteLine("So far, you've guessed:");
                for (int i = 0; i < answerPreview.Length; i++)
                {
                    Console.Write(answerPreview[i] + " ");
                }
                Console.WriteLine();

                Artist.PaintMan(livesRemaining);

                // Store the guess
                char guess = Console.ReadKey().KeyChar;

                // If they're wrong, subtract a life
                if (!Validator.IsGuessCorrect(secretWord, guess))
                    livesRemaining--;

                // If they're right, add letter to player2's construction of the word, in every position where that letter appears (this is displayed back to them at the start of the while loop)
                for (int i = 0; i < secretWordInput.Length; i++)
                {
                    if (secretWord[i] == guess)
                        answerPreview[i] = guess;
                }

                //if they've got the whole word, end the game
                string completedAnswer = new string(answerPreview);

                if (completedAnswer == secretWord)
                    playerWon = true;
            }

            if (playerWon == true)
            {
                Console.WriteLine($"YOU WON! {playerTwoName}'s word was:");
                for (int i = 0; i < answerPreview.Length; i++)
                {
                    Console.Write(answerPreview[i] + " ");
                }
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("GAME OVER!!! YOU RAN OUT OF LIVES!");
                Console.WriteLine();
                Artist.PaintMan(0);
            }
        }
    }
}
