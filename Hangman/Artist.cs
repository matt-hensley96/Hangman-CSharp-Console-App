using System;

namespace Hangman
{
    internal static class Artist
    {
        private static readonly string[] _eightLives =
        {
            "         ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _sevenLives =
        {
            "  +---+  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _sixLives =
        {
            "  +---+  ",
            "  |   |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _fiveLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            "      |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _fourLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            "  |   |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _threeLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            " /|   |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _twoLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            @" /|\  |  ",
            "      |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _oneLives =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            @" /|\  |  ",
            " /    |  ",
            "      |  ",
            "========="
        };

        private static readonly string[] _zeroLives =
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
                8 => _eightLives,
                7 => _sevenLives,
                6 => _sixLives,
                5 => _fiveLives,
                4 => _fourLives,
                3 => _threeLives,
                2 => _twoLives,
                1 => _oneLives,
                0 => _zeroLives,
                _ => new string[7]
            };

            foreach (string line in currentDrawing)
                Console.WriteLine(line);
        }
    }
}