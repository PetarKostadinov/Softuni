using System;

namespace seling
{
    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col, int n)
        {
            this.Size = n;
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
                if (value >= this.Size || value < 0)
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
                if (value >= this.Size || value < 0)
                {
                    throw new Exception();
                }

                this.col = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            FillUp(matrix);
            var snake = GetSnakePosition(n, matrix);
            var burrow = GetBurrowPosition(n, matrix);
            int money = 0;

            while (money < 50)
            {
                string command = Console.ReadLine();
                matrix[snake.Row, snake.Col] = '-';
                try
                {
                    MovePlayer(snake, command);

                    if (matrix[snake.Row, snake.Col] == 'O')
                    {
                        matrix[snake.Row, snake.Col] = '-';

                        snake = burrow;
                    }
                    else if (matrix[snake.Row, snake.Col] != '-')
                    {
                        money += int.Parse((matrix[snake.Row, snake.Col]).ToString());
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }

            if (money >= 50)
            {
                matrix[snake.Row, snake.Col] = 'S';
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {money}");

            PrintMatrix(matrix);
        }
        private static Position GetSnakePosition(int n, char[,] matrix)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == 'S')
                    {
                        position = new Position(row, col, n);
                        position.Row = row;
                        position.Col = col;
                        break;
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
        private static Position GetBurrowPosition(int n, char[,] matrix)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == 'O')
                    {
                        position = new Position(row, col, n);
                        position.Row = row;
                        position.Col = col;
                    }
                }
            }
            return position;
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

    }

}
