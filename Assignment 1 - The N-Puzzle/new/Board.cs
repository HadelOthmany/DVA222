using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theNPuzzle
{
    class Board
    {
        private int[,] playPuzzle;
        private int[,] solvedPuzzle;
        private int size;
        private Random rand;

        public Board(int size)
        {
            this.size = size;
            playPuzzle = CreateNPuzzle(size);
            solvedPuzzle = CreateNPuzzle(size);
            rand = new Random();
        }

        private int[,] CreateNPuzzle(int size)
        {
            int[,] newPuzzle = new int[size, size];
            int count = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newPuzzle[i, j] = count;
                    count++;
                }
            }
            newPuzzle[size - 1, size - 1] = 0;

            return newPuzzle;
        }

        private int[] FindEmptySpace(int[,] array)
        {
            int[] index = new int[2];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (array[i, j] == 0)
                    {
                        index[0] = i;
                        index[1] = j;

                    }
                }
            }
            return index;
        }

        public void Shuffle()
        {
            int[] falttenArray = Flatten();
            ShuffleFlatten(falttenArray);
            ReshapeTo2D(falttenArray);
        }


        public void MoveTile(Direction direction)
        {
            int[] emptyTileIndexArr = FindEmptySpace(playPuzzle);
            int emptyTileRowIndex = emptyTileIndexArr[0];
            int emptyTileColIndex = emptyTileIndexArr[1];
            int temp;

            switch (direction)
            {
                case Direction.Left:
                    if (emptyTileColIndex > 0)
                    {
                        temp = playPuzzle[emptyTileRowIndex, emptyTileColIndex];
                        playPuzzle[emptyTileRowIndex, emptyTileColIndex] = playPuzzle[emptyTileRowIndex, emptyTileColIndex - 1];
                        playPuzzle[emptyTileRowIndex, emptyTileColIndex - 1] = temp;
                    }
                    break;

                case Direction.Right:
                    if (emptyTileColIndex < size - 1)
                    {
                        temp = playPuzzle[emptyTileRowIndex, emptyTileColIndex];
                        playPuzzle[emptyTileRowIndex, emptyTileColIndex] = playPuzzle[emptyTileRowIndex, emptyTileColIndex + 1];
                        playPuzzle[emptyTileRowIndex, emptyTileColIndex + 1] = temp;
                    }
                    break;

                case Direction.Up:
                    if (emptyTileRowIndex > 0)
                    {
                        temp = playPuzzle[emptyTileRowIndex, emptyTileColIndex];
                        playPuzzle[emptyTileRowIndex, emptyTileColIndex] = playPuzzle[emptyTileRowIndex - 1, emptyTileColIndex];
                        playPuzzle[emptyTileRowIndex - 1, emptyTileColIndex] = temp;
                    }
                    break;

                case Direction.Down:
                    if (emptyTileRowIndex < size - 1)
                    {
                        temp = playPuzzle[emptyTileRowIndex, emptyTileColIndex];
                        playPuzzle[emptyTileRowIndex, emptyTileColIndex] = playPuzzle[emptyTileRowIndex + 1, emptyTileColIndex];
                        playPuzzle[emptyTileRowIndex + 1, emptyTileColIndex] = temp;
                    }
                    break;

            }
        }
        public bool IsSolved()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (playPuzzle[i, j] != solvedPuzzle[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void PrintPuzzle()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("+");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();

                Console.Write("|");
                for (int j = 0; j < size; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"{playPuzzle[i, j],3}|");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.Write("+");
            for (int j = 0; j < size; j++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }

            private int[] Flatten()
    {
        int[] array = new int[size * size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                array[i * size + j] = playPuzzle[i, j];
            }
        }
        return array;
    }

    private void ShuffleFlatten(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    private void ReshapeTo2D(int[] array)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                playPuzzle[i, j] = array[i * size + j];
            }
        }
    }

    }


}
