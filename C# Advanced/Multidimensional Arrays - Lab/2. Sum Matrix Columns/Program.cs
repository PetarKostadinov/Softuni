using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
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
     
            for (int col = 0; col < matrix.GetLength(1); col++)                     
            {
                int sumCols = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)                 
                {                                                                   
                    sumCols += matrix[row, col];     
                }

                Console.WriteLine(sumCols);
            }
        }

        public static void FillUpMatrix(int[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
