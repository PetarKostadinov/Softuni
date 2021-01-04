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
            int sumD2 = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int number = num[row, col];

                    if (row == col)   // the number is at the main diagonal
                    {
                        sumD1 += number;
                    }

                    if (col == n - 1 - row)  //->the number is at the secondary diagonal
                    {
                        sumD2 += number;
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumD2 - sumD1));

        }

        public static void PrintMatrix(int[,] num) // in that case the particular method is not in use !
        {
            for (int row = 0; row < num.GetLength(0); row++)
            {
                for (int col = 0; col < num.GetLength(1); col++)
                {
                    Console.Write(num[row, col] + " ");
                }
                Console.WriteLine();
            }
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
