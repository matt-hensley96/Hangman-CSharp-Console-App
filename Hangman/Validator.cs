using System;
using System.Text.RegularExpressions;

namespace Hangman
{
    internal static class Validator
    {
        public static bool IsSecretWordValid(string secretWordInput)
        {
            if (!secretWordInput.Contains(" ") && Regex.IsMatch(secretWordInput, @"^[a-zA-Z]+$"))
                return true;

            Console.WriteLine("That's not valid. It should be a single word containing letters only- Try again.");
            return false;
        }

        public static bool IsGuessCorrect(string secretWord, char guess)
        {
            if (char.IsLetter(guess))
                guess = char.ToUpper(guess);

            if (!secretWord.Contains(guess))
            {
                Console.WriteLine("That letter isn't in the secret word!");
                Console.WriteLine();
                return false;
            }

            Console.WriteLine("CORRECT!");
            Console.WriteLine();
            return true;
        }

        public static bool IsGuessValid(in char guess)
        {
            if (char.IsLetter(guess))
                return true;

            Console.WriteLine("That's not a valid guess. You should have guessed a letter- Try again!");
            return false;
        }
    }
}