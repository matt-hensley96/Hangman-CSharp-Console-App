using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    internal static class Validator
    {
        public static string ForceUserToGiveValidSecretWord(string secretWordInput)
        {
            var input = secretWordInput;
            var numberOfUniqueCharacters = (new HashSet<char>(input)).Count;
            
            while (input.Contains(" ") || !Regex.IsMatch(input, @"^[a-zA-Z]+$") || numberOfUniqueCharacters > 9)
            {
                Console.WriteLine("That's not valid.");
                input = Console.ReadLine();
                numberOfUniqueCharacters = (new HashSet<char>(input)).Count;
            }

            return input;
        }

        public static bool IsGuessCorrect(string secretWord, char guess)
        {
            Console.WriteLine();

            if (!secretWord.Contains(guess)) 
            {
                Console.WriteLine("That letter isn't in the secret word!");
                return false;
            }

            Console.WriteLine();
            Console.WriteLine("CORRECT!");
            return true;
        }
    }
}
