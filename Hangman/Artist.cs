using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Artist
    {
        // Create an array for each state of 9 lives. In a given array, each element should be a line of the picture
        static string[] eightLives =
        {  "         ",
           "      |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] sevenLives =
        {  "  +---+  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] sixLives =
        {  "  +---+  ",
           "  |   |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] fiveLives =
        {  "  +---+  ",
           "  |   |  ",
           "  O   |  ",
           "      |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] fourLives =
        {  "  +---+  ",
           "  |   |  ",
           "  O   |  ",
           "  |   |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] threeLives =
        {  "  +---+  ",
           "  |   |  ",
           "  O   |  ",
           " /|   |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] twoLives =
        {  "  +---+  ",
           "  |   |  ",
           "  O   |  ",
          @" /|\  |  ",
           "      |  ",
           "      |  ",
           "========="
        };

        static string[] oneLives =
        {  "  +---+  ",
           "  |   |  ",
           "  O   |  ",
          @" /|\  |  ",
           " /    |  ",
           "      |  ",
           "========="
        };

        static string[] zeroLives =
        {  "  +---+  ",
           "  |   |  ",
           "  O   |  ",
          @" /|\  |  ",
          @" / \  |  ",
           "      |  ",
           "========="
        };

        public static void PaintMan(int livesRemaining) 
        {
            string[] currentDrawing = new string[7];

            switch (livesRemaining)
            {
                case 8:
                    currentDrawing = eightLives;
                    break;
                case 7:
                    currentDrawing = sevenLives;
                    break;
                case 6:
                    currentDrawing = sixLives;
                    break;
                case 5:
                    currentDrawing = fiveLives;
                    break;
                case 4:
                    currentDrawing = fourLives;
                    break;
                case 3:
                    currentDrawing = threeLives;
                    break;
                case 2:
                    currentDrawing = twoLives;
                    break;
                case 1:
                    currentDrawing = oneLives;
                    break;
                case 0:
                    currentDrawing = zeroLives;
                    break;
            }


            // After each guess, call this method loop to through the array for livesRemaining, doing a console.writeline on each element
            foreach (string line in currentDrawing)
            {
                Console.WriteLine(line);
            }

        }
    }
}


// oneLivesDrawing
//  +---+
//  |   |
//  O   |
// /|\  |
// /    |
//      |
//=========

// zeroLivesDrawing
//  +---+
//  |   |
//  O   |
// /|\  |
// / \  |
//      |
//=========