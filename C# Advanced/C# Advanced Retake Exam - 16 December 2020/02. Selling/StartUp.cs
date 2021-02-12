using System;
using System.Linq;

namespace Selling
{
    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col, int matrixSize)
        {
            this.MatrixSize = matrixSize;
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 0 || value >= this.MatrixSize)
                {
                    throw new Exception("Invalid size");
                }

                this.row = value;
            }
        }
        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                if (value < 0 || value >= this.MatrixSize)
                {
                    throw new Exception("Invalid size");
                }

                this.col = value;
            }
        }
        public int MatrixSize { get; set; }

    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
       
            int money = 0;

            FillUpMatrix(matrix);

            var positionS = GetSPosioion(matrix, n);

            while (true)
            {
                string command = Console.ReadLine();

                try
                {
                    positionS = GetSPosioion(matrix, n);

                    matrix[positionS.Row, positionS.Col] = '-';

                    if (command == "left")
                    {
                        positionS.Col--;
                    }
                    else if (command == "right")
                    {
                        positionS.Col++;
                    }
                    else if (command == "up")
                    {
                        positionS.Row--;
                    }
                    else if (command == "down")
                    {
                        positionS.Row++;
                    }
                }
                catch (Exception)
                {
                    matrix[positionS.Row, positionS.Col] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (matrix[positionS.Row, positionS.Col] == '-')
                {
                    matrix[positionS.Row, positionS.Col] = 'S';
                }

                if (Char.IsDigit(matrix[positionS.Row, positionS.Col]))
                {
                    var curr = matrix[positionS.Row, positionS.Col] - '0';
                    money += curr;
                    matrix[positionS.Row, positionS.Col] = 'S';

                    if (money >= 50)
                    {
                        Console.WriteLine("Good news! You succeeded in collecting enough money!");
                        break;
                    }
                }
                if (matrix[positionS.Row, positionS.Col] == 'O')
                {
                    matrix[positionS.Row, positionS.Col] = '-';

                    FindSecondPillarAndChangeIt(matrix);
                }
            }
            Console.WriteLine($"Money: {money}");
            Print(matrix);
        }

        private static void FillUpMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static void Print(char[,] matrix)
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

        private static void FindSecondPillarAndChangeIt(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        matrix[row, col] = 'S';
                    }
                }
            }
        }

        static Position GetSPosioion(char[,] matrix, int matrixSize)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        position = new Position(row, col, matrixSize);
                    }
                }
            }
            return position;
        }
    }
}