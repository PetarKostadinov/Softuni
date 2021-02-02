using System;

namespace ReVolt
{

    public class Position
    {
        public Position(int row, int col)
        {
            Col = col;
            Row = row;
        }
        public int Row { get; set; }
  
        public int Col { get; set; }

        public  bool IsSafe(int rowCount, int colCount)
        {
            if (Row < 0 || Col < 0)
            {
                return false;
            }
            if (Row >= rowCount || Col >= colCount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int countOfCommands = int.Parse(Console.ReadLine());

            FillUpMatrix(matrix);
            var player = GetPlayerPosition(matrix);

            matrix[player.Row, player.Col] = '-';

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                MovePlayer(matrix, player, command, n);

                if (matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(matrix, player, command, n);
                }

                if (matrix[player.Row, player.Col] == 'T')
                {
                    Position direction = GetDirection(command);

                    player.Row += direction.Row * -1;
                    player.Col += direction.Col * -1;
                }

                if (matrix[player.Row, player.Col] == 'F')
                {
                    Console.WriteLine("Player won!");

                    matrix[player.Row, player.Col] = 'f';
                    PrintMatrix(matrix);
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            matrix[player.Row, player.Col] = 'f';
            PrintMatrix(matrix);
        }
        static Position GetDirection(string command)
        {
            int row = 0;
            int col = 0;

            if (command == "left")
            {
                col = -1;
            }
            if (command == "right")
            {
                col = 1;
            }
            if (command == "up")
            {
                row = -1;
            }
            if (command == "down")
            {
                row = 1;
            }

            return new Position(row, col);

        }
        static Position MovePlayer(char[,] matrix, Position player, string command, int dimension)
        {
            if (command == "left")
            {
                player.Col--;
                if (!player.IsSafe(dimension, dimension))
                {
                    player.Col = dimension - 1;
                }

            }
            if (command == "right")
            {
                player.Col++;
                if (!player.IsSafe(dimension, dimension))
                {
                    player.Col = 0;
                }
            }
            if (command == "up")
            {
                player.Row--;
                if (!player.IsSafe(dimension, dimension))
                {
                    player.Row = dimension - 1;
                }
            }
            if (command == "down")
            {
                player.Row++;
                if (!player.IsSafe(dimension, dimension))
                {
                    player.Row = 0;
                }
            }

            return player;
        }
        static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row,col);
                    }
                }
            }
            return position;
        }
        private static void FillUpMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                input.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static void PrintMatrix(char[,] matrix)
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

