using System;
using System.Collections.Generic;
using System.Linq;

namespace BombMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillUp(matrix);

            List<int> data = Console.ReadLine()
                            .Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            Queue<int> coordinates = new Queue<int>(data);

            while (coordinates.Count != 0)
            {
                int row = coordinates.Dequeue();
                int col = coordinates.Dequeue();

                int power = matrix[row, col];

                Explosions(matrix, row, col, power);
            }

            int collector = 0;
            int alive = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    collector += item;
                    alive++;
                }
            }
            Console.WriteLine($"Alive cells: {alive}");

            Console.WriteLine($"Sum: {collector}");

            Print(matrix);

        }

        private static void Explosions(int[,] matrix, int row, int col, int power)
        {
            if (power > 0)
            {
                if (InRange(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= power;
                }

                if (InRange(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= power;
                }

                if (InRange(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= power;
                }

                if (InRange(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= power;
                }

                if (InRange(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= power;
                }

                if (InRange(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= power;
                }

                if (InRange(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= power;
                }

                if (InRange(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= power;
                }

                matrix[row, col] = 0;
            }
        }

        private static void FillUp(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static bool InRange(int[,] matrix, int row, int col)
        {
            if (row >= 0
                        && row < matrix.GetLength(0)
                        && col >= 0
                        && col < matrix.GetLength(1)
                        && matrix[row, col] > 0)
            {
                return true;
            }

            return false;
        }

        static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
