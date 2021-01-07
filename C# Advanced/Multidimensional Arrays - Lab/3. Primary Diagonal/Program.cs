using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] num = new int[n, n];

            FillUpMatrix(num);
            int sumD1 = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int number = num[row, col];

                    if (row == col)   // the number is at the main diagonal
                    {
                        sumD1 += number;
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumD1));

        }

        public static void FillUpMatrix(int[,] num)
        {
            for (int row = 0; row < num.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < num.GetLength(1); col++)
                {
                    num[row, col] = currRow[col];
                }
            }
        }
    }
}
