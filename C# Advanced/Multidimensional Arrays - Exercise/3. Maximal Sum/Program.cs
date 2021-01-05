using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];
            int targetRow = 0;
            int targetCol = 0;

            int[,] matrix = new int[rows, cols];

            FillupMatrix(matrix);

            int maxValue = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {                                                                    //1  2  3
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)          //4  5  6 
                {                                                                //7  8  9
                    int currSum = 
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] 
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxValue)
                    {
                        maxValue = currSum;
                        targetRow = row;
                        targetCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxValue}");

            for (int row = targetRow; row <= targetRow + 2; row++)
            {
                for (int col = targetCol; col <= targetCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillupMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }
    }
}
