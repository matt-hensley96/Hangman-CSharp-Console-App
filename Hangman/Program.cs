using System;

namespace Hangman
{
    internal static class Program
    {
        private static void Main()
        {
            bool playing = true;

            while (playing)
            {
                Presenter.ShowNameOfGame();

                string[] playerNames = Presenter.GetPlayerNames();
                string secretWord = Presenter.GetSecretWord(playerNames[0]);
                char[] answerPreview = Presenter.GetAnswerPreview(secretWord);

                Presenter.PresentGame(playerNames, secretWord, answerPreview);

                Console.WriteLine("Press enter to play again!");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    Console.Clear();
                else
                    playing = false;
            }
        }
    }
}