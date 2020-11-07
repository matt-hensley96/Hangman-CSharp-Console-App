using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Hangman
{
    internal static class Validator
    {
        public static string ForceUserToGiveValidSecretWord(string secretWordInput)
        {
            string input = secretWordInput;
            int numberOfUniqueCharacters = new HashSet<char>(input).Count;

            while (input.Contains(" ") || !Regex.IsMatch(input, @"^[a-zA-Z]+$") || numberOfUniqueCharacters > 9)
            {
                Console.WriteLine();
                Console.WriteLine("That's not valid.");
                input = null;

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter)
                        break;

                    if (key.Key != ConsoleKey.Backspace)
                        Console.Write("*");

                    input += key.KeyChar;
                }

                numberOfUniqueCharacters = new HashSet<char>(input).Count;
            }

            return input;
        }

        public static bool IsGuessCorrect(string secretWord, char guess)
        {
            Console.WriteLine();

            if (char.IsLetter(guess))
                guess = char.ToUpper(guess);

            if (!secretWord.Contains(guess))
            {
                Console.WriteLine("That letter isn't in the secret word!");
                return false;
            }

            Console.WriteLine("CORRECT!");
            return true;
        }
    }
}