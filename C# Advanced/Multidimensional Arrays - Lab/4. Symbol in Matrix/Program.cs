using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                var currRow = input.ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            var charr = Console.ReadLine();

            bool isfound = false;

            int foundRow = 0;
            int fondCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isfound)
                {
                    break;
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == char.Parse(charr))
                    {
                        fondCol = col;
                        foundRow = row;
                        isfound = true;
                        break;
                    }
                }
            }
            if (!isfound)
            {   
                Console.WriteLine($"{charr} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({foundRow}, {fondCol})");
            }
          
        }
    }
}
