using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Presenter.Greeting();

            // Initialise anything needed later
            int livesRemaining = 9;

            // Store the names of the two players
            Console.WriteLine("Player 1, enter your name, then hit Enter.");
            string playerOneName = Console.ReadLine();
            Console.WriteLine("Player 2, enter your name, then hit Enter.");
            string playerTwoName = Console.ReadLine();

            // Stores the secret word
            Console.WriteLine($"{playerOneName}, type the secret word, then hit Enter.");
            string secretWord = Console.ReadLine();
            // TO DO: Validate that the secret word doesn't have more unique letters than player 2's starting number of lives (9).
            // TO DO: Obscure the letters in the secret word (as the user types them) using * characters (like a password)

            // TO DO: Player 2 keeps guessing letters from player 1's word
            Console.WriteLine($"{playerTwoName}, you have {livesRemaining} lives left. Guess a letter from the secret word, then hit enter.");
            string guessOne = Console.ReadLine();
            //      TO DO: If they get a letter correct, every instance of this letter (and previously guessed letters) is displayed in its position, e.g R*E*E**
            //      TO DO: If they get a letter wrong, they lose a life
            //      TO DO: Once they have zero lives, it's game over and the full word gets revealed
            // TO DO: Add an ASCI UI as suggested in the email
        }
    }
}
