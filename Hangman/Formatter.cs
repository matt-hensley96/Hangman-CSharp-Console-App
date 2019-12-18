using System;
using System.Text;

namespace Hangman
{
    internal static class Presenter
    {
        public static void Greeting()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            StringBuilder header = new StringBuilder();
            header.Append('-', 8).AppendLine().Append("HANGMAN").AppendLine().Append('-', 8);
            Console.WriteLine(header);
        }
    }
}