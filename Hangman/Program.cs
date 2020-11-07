using System;

namespace Hangman
{
    internal static class Program
    {
        private static void Main()
        {
            // TO DO: In Presenter.PlayGame(), Log the players guesses on the console in case they forget which letter's they already guessed
            Presenter.ShowNameOfGame();

            string[] playerNames = Presenter.GetPlayerNames();
            string secretWord = Presenter.GetSecretWord(playerNames[0]);
            char[] answerPreview = Presenter.GetAnswerPreview(secretWord);

            Presenter.PresentGame(playerNames, secretWord, answerPreview);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}