using System;

namespace Revolt1
{
    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col, int size)
        {
            this.Row = row;
            this.Col = col;
            this.Size = size;
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
                if (value >= this.Size)
                {
                    value = 0;
                }
                else if (value < 0)
                {
                    value = this.Size - 1;
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
                if (value >= this.Size)
                {
                    value = 0;
                }
                else if (value < 0)
                {
                    value = this.Size - 1;
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
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            FillUp(matrix);

            var player = GetPlayersPosition(n, matrix);

            matrix[player.Row, player.Col] = '-';

            bool playerWons = false;

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                MovePlayer(player, command);
                if (matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(player, command);
                }
                else if (matrix[player.Row, player.Col] == 'T')
                {
                    StepBack(player, command);
                }
                else if (matrix[player.Row, player.Col] == 'F')
                {
                    matrix[player.Row, player.Col] = 'f';
                    playerWons = true;
                    break;
                }
               
            }

            if (playerWons)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                matrix[player.Row, player.Col] = 'f';
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
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

        private static void StepBack(Position player, string command)
        {
            if (command == "up")
            {
                player.Row++;
            }
            else if (command == "down")
            {
                player.Row--;
            }
            else if (command == "left")
            {
                player.Col++;
            }
            else if (command == "right")
            {
                player.Col--;
            }
        }

        private static void MovePlayer(Position player, string command)
        {
            if (command == "up")
            {
                player.Row--;
            }
            else if (command == "down")
            {
                player.Row++;
            }
            else if (command == "left")
            {
                player.Col--;
            }
            else if (command == "right")
            {
                player.Col++;
            }
        }

        private static Position GetPlayersPosition(int n, char[,] matrix)
        {
            Position position = null;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row, col, n);
                        position.Row = row;
                        position.Col = col;
                    }
                }
            }
            return position;
        }

        private static void FillUp(char[,] matrix)
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
    }
}
