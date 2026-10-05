using System;

namespace theNPuzzle
{
    class GameWorld
    {
        private int moves;

        public void RunGame()
        {
            Console.WriteLine("Welcome to the N Puzzle Game!");

            int size = GetValidPuzzleSize();

            Board board = new Board(size);
            board.Shuffle();

            InputHandler inputHandler = new InputHandler(board);
            while (!board.IsSolved())
            {
                Console.WriteLine("Move the empty tile using the arrow keys on the Keyboard.");
                board.PrintPuzzle();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                inputHandler.HandleKeyClick(keyInfo);
                Console.Clear();

                if (IsValidKey(keyInfo.Key))
                {
                    moves++;
                }
            }

            Console.WriteLine($"Congratulations! You solved the puzzle in {moves} moves!");
        }

        private int GetValidPuzzleSize()
        {
            int size = 0;

            while (true)
            {
                Console.WriteLine("Please enter the size of the puzzle (e.g., 3 for a 3x3 puzzle):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out size) && size > 0)
                {
                    return size;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer greater than zero.");
                }
            }
        }

        private bool IsValidKey(ConsoleKey key)
        {
            return key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow;
        }
    }
}
