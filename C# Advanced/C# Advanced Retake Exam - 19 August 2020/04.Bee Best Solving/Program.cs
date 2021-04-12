using System;

namespace Bee
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
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            FillUp(matrix);

            var bee = GetBeePosition(n, matrix);
            int polinationed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
            
                    matrix[bee.Row, bee.Col] = '.';
                try
                {
                    MoveBee(bee, command);
                   
                    if (matrix[bee.Row, bee.Col] == 'O')
                    {
                        matrix[bee.Row, bee.Col] = '.';
                        MoveBee(bee, command);
                       
                    }
                    if (matrix[bee.Row, bee.Col] == 'f')
                    {
                        polinationed++;
                    }
                   
                    matrix[bee.Row, bee.Col] = 'B';
                }
                catch (Exception)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }

            if (polinationed < 5)
            {
                
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinationed} flowers more");
            }
            else
            {
               
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationed} flowers!");
            }
           

            PrintMatrix(matrix);
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
        private static Position GetBeePosition(int n, char[,] matrix)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == 'B')
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
   
        private static void MoveBee(Position player, string command)
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
