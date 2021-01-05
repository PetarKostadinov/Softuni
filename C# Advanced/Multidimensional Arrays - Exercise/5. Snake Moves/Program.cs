using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string snakeName = Console.ReadLine();

            int rows = input[0];
            int cols = input[1];

            int currLetter = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        currLetter = fillLetters(snakeName, currLetter, matrix, row, col);
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        currLetter = fillLetters(snakeName, currLetter, matrix, row, col);
                    }
                }
            }
            PrintMatrix(matrix);
        }

        private static int fillLetters(string snakeName, int currLetter, char[,] matrix, int row, int col)
        {
            matrix[row, col] = snakeName[currLetter];

            currLetter++;

            if (currLetter == snakeName.Length)
            {
                currLetter = 0;
            }

            return currLetter;
        }

        public static void PrintMatrix(char[,] num)
        {
            for (int row = 0; row < num.GetLength(0); row++)
            {
                for (int col = 0; col < num.GetLength(1); col++)
                {
                    Console.Write(num[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
