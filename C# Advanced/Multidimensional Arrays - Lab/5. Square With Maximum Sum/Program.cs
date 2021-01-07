using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            FillUpMatrix(matrix);
            
            int maxSum = int.MinValue;

            int CurrRow = 0;
            int CurrCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum2x2Matrix = matrix[row, col]
                                     + matrix[row, col + 1] 
                                     + matrix[row + 1, col] 
                                     + matrix[row + 1, col + 1];

                    if (sum2x2Matrix > maxSum)
                    {
                        maxSum = sum2x2Matrix;

                        CurrRow = row;
                        CurrCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[CurrRow, CurrCol]} {matrix[CurrRow, CurrCol + 1]}");
            Console.WriteLine($"{matrix[CurrRow + 1, CurrCol]} {matrix[CurrRow + 1, CurrCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static void FillUpMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
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
