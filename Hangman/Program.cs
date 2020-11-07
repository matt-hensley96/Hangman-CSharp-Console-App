using System;

namespace Hangman
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var livesRemaining = 8;
            var playerWon = false;

            Presenter.Greeting();

            string[] playerNames = Presenter.GetPlayerNames();
            string secretWord = Presenter.GetSecretWord(playerNames);
            char[] answerPreview = Presenter.CreateAnswerPreview(secretWord);

            while (livesRemaining > 0 && !playerWon)
            {
                Presenter.AskForGuess(playerNames, livesRemaining, answerPreview);
                char guess = Console.ReadKey().KeyChar;
                Console.Clear();

                if (!Validator.IsGuessCorrect(secretWord, guess))
                    livesRemaining--;

                Presenter.UpdateAnswerPreview(guess, secretWord, answerPreview);

                var completedAnswer = new string(answerPreview);

                if (completedAnswer == secretWord)
                    playerWon = true;
            }

            Presenter.GiveResults(playerNames, answerPreview, playerWon);
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}