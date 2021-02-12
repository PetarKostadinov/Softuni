using System;

namespace Bee
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

        public int MatrixSize { get; set; }
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
    }
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            FillUpMatrix(matrix);

            int pollinated = 0;
            int pollinatedTarget = 5;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                
                    var positionB = GetSPosioion(matrix, n);

                try
                {
                    matrix[positionB.Row, positionB.Col] = '.';

                    if (command == "left")
                    {
                        positionB.Col--;
                    }
                    else if (command == "right")
                    {
                        positionB.Col++;
                    }
                    else if (command == "up")
                    {
                        positionB.Row--;
                    }
                    else if (command == "down")
                    {
                        positionB.Row++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[positionB.Row, positionB.Col] == 'O')
                {
                    try
                    {
                        matrix[positionB.Row, positionB.Col] = '.';

                        if (command == "left")
                        {
                            positionB.Col--;
                        }
                        else if (command == "right")
                        {
                            positionB.Col++;
                        }
                        else if (command == "up")
                        {
                            positionB.Row--;
                        }
                        else if (command == "down")
                        {
                            positionB.Row++;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }
               
                if (matrix[positionB.Row, positionB.Col] == 'f')
                {
                    matrix[positionB.Row, positionB.Col] = 'B';

                    pollinated++;
                }
                else if (matrix[positionB.Row, positionB.Col] == '.')
                {
                    matrix[positionB.Row, positionB.Col] = 'B';
                }
               
            }
            if (pollinated >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinated} flowers!");
            }
            else 
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {pollinatedTarget - pollinated} flowers more");
            }

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

        static Position GetSPosioion(char[,] matrix, int matrixSize)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        position = new Position(row, col, matrixSize);
                    }
                }
            }
            return position;
        }

    }
}
