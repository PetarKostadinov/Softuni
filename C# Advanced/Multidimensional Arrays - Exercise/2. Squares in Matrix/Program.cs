using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];

            FillUpMatrix(matrix);

            int count = 0;

            for (int singleRow = 0; singleRow < rows - 1; singleRow++)
            {
                for (int singleCol = 0; singleCol < cols - 1; singleCol++)
                {
                    char currElement = matrix[singleRow, singleCol];

                    if (currElement == matrix[singleRow, singleCol + 1] 
                        && currElement == matrix[singleRow + 1, singleCol] 
                        &&currElement == matrix[singleRow + 1, singleCol + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static void FillUpMatrix(char[,] num)
        {
            for (int row = 0; row < num.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < num.GetLength(1); col++)
                {
                    num[row, col] = currRow[col];
                }
            }
        }
    }
}
