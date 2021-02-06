using System;
using System.Linq;

namespace _02._Snake
{
     class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rowS = -1;
            int colS = -1;

            char[,] matrix = new char[n, n];

            int firstBRow = -1;
            int firstBCol = -1;
            int secondBRow = -1;
            int secondBCol = -1;
            FillUpMatrix(matrix);
           
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                         rowS = row;
                         colS= col;
                     
                    }

                    if (matrix[row, col] == 'B')
                    {
                        if (firstBCol == -1)
                        {
                            firstBRow = row;
                            firstBCol = col;

                        }
                        else
                        {
                            secondBRow = row;
                            secondBCol = col;
                        }
                    }
                }
            }
            matrix[rowS, colS] = '.';
            int foodCount = 0;

            while (true)
            {

                if (foodCount > 9)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    matrix[rowS, colS] = 'S';
                    break;
                }

                string commands = Console.ReadLine();

                if (commands == "left")
                {
                    colS--;
                }
                if (commands == "right")
                {
                    colS++;
                }
                if (commands == "up")
                {
                    rowS--;
                }
                if (commands == "down")
                {
                    rowS++;
                }
                if (!IsValid(matrix, rowS, colS))
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                if (matrix[rowS, colS] == '*')
                {
                    foodCount++;
                }
                if (matrix[rowS, colS] == 'B')
                {
                    matrix[rowS, colS] = '.';
                    if (firstBRow == rowS && firstBCol == colS)
                    {
                        rowS = secondBRow;
                        colS = secondBCol;
                    }
                    else
                    {
                        rowS = firstBRow;
                        colS = firstBCol;
                    }
                }
                matrix[rowS, colS] = '.';

              
            }
            Console.WriteLine($"Food eaten: {foodCount}");
            Print(matrix);
        }

        public static void FillUpMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();

                var input = data.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
         static bool IsValid(char[,] matrix, int row, int col)
        {
            var checkIsCorect = row >= 0 
                             && row < matrix.GetLength(0) 
                             && col >= 0 
                             && col < matrix.GetLength(1) ? true : false;

            if (checkIsCorect == true)
            {
                return true;
            }
            return false;
        }
       
        public static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
