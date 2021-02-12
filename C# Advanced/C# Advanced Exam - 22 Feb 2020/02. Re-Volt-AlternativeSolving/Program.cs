using System;

namespace testMatrix
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
                if (value < 0)
                {
                    value = MatrixSize - 1;
                }
                else if (value >= this.MatrixSize)
                {
                    value = 0;
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
                if (value < 0)
                {
                    value = MatrixSize - 1;
                }
                else if (value >= this.MatrixSize)
                {
                    value = 0;
                }

                this.col = value;
            }
        }
        public int MatrixSize { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfComands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            FillUp(matrix);

            for (int i = 0; i < countOfComands; i++)
            {
                string command = Console.ReadLine();

                var position = GetPosition(matrix, n);

                matrix[position.Row, position.Col] = '-';

                Move(command, position);

                if (matrix[position.Row, position.Col] == 'B')
                {

                    Move(command, position);
                }
                if (matrix[position.Row, position.Col] == 'T')
                {
                    StepBack(command, position);
                }
                if (matrix[position.Row, position.Col] == 'F')
                {
                    matrix[position.Row, position.Col] = 'f';
                    Console.WriteLine("Player won!");

                    break;
                }
                if (matrix[position.Row, position.Col] == '-')
                {
                    matrix[position.Row, position.Col] = 'f';
                }
            }

            if (ContainsF(matrix))
            {
                Console.WriteLine("Player lost!");
            }
            Print(matrix);
        }

        public static void Move(string command, Position position)
        {
            if (command == "left")
            {
                position.Col--;
            }
            else if (command == "right")
            {
                position.Col++;
            }
            else if (command == "up")
            {
                position.Row--;
            }
            else if (command == "down")
            {
                position.Row++;
            }
        }

        public static void StepBack(string command, Position position)
        {
            if (command == "left")
            {
                position.Col++;
            }
            else if (command == "right")
            {
                position.Col--;
            }
            else if (command == "up")
            {
                position.Row++;
            }
            else if (command == "down")
            {
                position.Row--;
            }
        }

        public static void FillUp(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
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

        public static Position GetPosition(char[,] matrix, int matrixSize)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row, col, matrixSize);

                    }
                }
            }
            return position;
        }

        public static bool ContainsF(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'F')
                    {
                        return true;

                    }
                }
            }
            return false;
        }
    }

}
