namespace P02_Matrices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Position
    {
        private int row;
        private int col;

        public Position(int size, int row, int col)
        {
            this.Size = size;
            this.Row = row;
            this.Col = col;
        }

        public int Size { get; set; }
        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 0 || value >= this.Size)
                {
                    throw new Exception();
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
                if (value < 0 || value >= this.Size)
                {
                    throw new Exception();
                }

                this.col = value;
            }
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            char[,] matrix = new char[dimension, dimension];

            List<string> commands = Console.ReadLine().Split().ToList();

            FillUp(matrix);

            var position = GetPosition(matrix, dimension);

            int coalCount = 0;

            foreach (var direction in commands)
            {
                try
                {
                    matrix[position.Row, position.Col] = '*';
                    Move(position, direction);
                }
                catch (Exception)
                {
                    continue;
                }
                
                if (matrix[position.Row, position.Col] == 'c')
                {
                    coalCount++;
                    matrix[position.Row, position.Col] = '*';

                    if (CheckForCoal(matrix) == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({position.Row}, {position.Col})");

                        return;
                    }   
                }
   
                if (matrix[position.Row, position.Col] == 'e')
                {
                    Console.WriteLine($"Game over! ({position.Row}, {position.Col})");

                    return;
                }
            }

            Console.WriteLine($"{CheckForCoal(matrix)} coals left. ({position.Row}, {position.Col})");
        }

        private static void Move(Position position, string direction)
        {
            if (direction == "left")
            {
                position.Col--;
            }
            else if (direction == "right")
            {
                position.Col++;
            }
            else if (direction == "up")
            {
                position.Row--;
            }
            else if (direction == "down")
            {
                position.Row++;
            }
        }

        public static int CheckForCoal(char[,] matrix)
        {
            int checkCount = 0;
           
            foreach (var item in matrix)
            {
                if (item == 'c')
                {
                    checkCount++;
                } 
            }

           return checkCount;
        }

        public static Position GetPosition(char[,] matrix, int size)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == 's')
                    {
                        position = new Position(size, row, col);
                    }
                }

            }

            return position;

        }

        public static void FillUp(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

        }

    }
}
