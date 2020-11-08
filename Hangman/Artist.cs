using System;

namespace Hangman
{
    internal static class Artist
    {
        private static readonly string[] _drawingOfHangmanWithEightLives =
        {
            "         ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithSevenLives =
        {
            "  +---+  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithSixLives =
        {
            "  +---+  ",
            "  |   |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithFiveLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithFourLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            "  |   |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithThreeLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            " /|   |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithTwoLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            @" /|\  |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithOneLife =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            @" /|\  |  ",
            " /    |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _drawingOfHangmanWithZeroLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            @" /|\  |  ",
            @" / \  |  ",
            "      |  ",
            "========="
        };

        public static void PaintMan(int livesRemaining)
        {
            string[] currentDrawing = livesRemaining switch
            {
                8 => _drawingOfHangmanWithEightLives,
                7 => _drawingOfHangmanWithSevenLives,
                6 => _drawingOfHangmanWithSixLives,
                5 => _drawingOfHangmanWithFiveLives,
                4 => _drawingOfHangmanWithFourLives,
                3 => _drawingOfHangmanWithThreeLives,
                2 => _drawingOfHangmanWithTwoLives,
                1 => _drawingOfHangmanWithOneLife,
                0 => _drawingOfHangmanWithZeroLives,
                _ => new string[7]
            };

            foreach (string line in currentDrawing)
                Console.WriteLine(line);
        }
    }
}