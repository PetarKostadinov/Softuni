using System;
using System.Collections.Generic;
using System.Linq;

namespace matrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            FillUpMatrixChars(matrix);

            int replaced = 0;

            int rowKiller = 0;
            int colKiller = 0;

            while (true)
            {
                int maxAtacks = int.MinValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int atacks = Atack(matrix, row, col);

                            if (atacks > maxAtacks)
                            {
                                maxAtacks = atacks;
                                rowKiller = row;
                                colKiller = col;

                            }
                        }

                    }
                }

                if (maxAtacks > 0)
                {
                    matrix[rowKiller, colKiller] = '0';

                    replaced++;

                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(replaced);
        }
        private static void FillUpMatrixChars(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                input.ToCharArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static int Atack(char[,] matrix, int row, int col)
        {
            int counter = 0;


            //if (ValidationMatrix(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
            //{
            //    counter++;
            //}
            //if (ValidationMatrix(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
            //{
            //    counter++;
            //}

            //return counter;

            List<int> ones = new List<int>() {1, -1, -1, 1 };
            List<int> twos = new List<int>() {2, 2, -2, -2 };

            for (int i = 0; i < 8; i++)
            {
                int index = i >= 4 ? i - 4 : i;
                int rowKiller = i < 4 ? twos[index] : ones[index];
                int colKiller = i >= 4 ? twos[index] : ones[index];

                if (ValidationMatrix(matrix, row - rowKiller ,col + colKiller) 
                    && matrix[row - rowKiller, col + colKiller] == 'K')
                {
                    counter++;
                }
            }
            return counter;
        }

        private static bool ValidationMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 
                && row < matrix.GetLength(0) 
                && col >= 0 
                && col < matrix.GetLength(1) ? true : false;
        }

    }
}
