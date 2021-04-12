using System;
using System.Linq;

namespace snake1
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

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = arr[0];
            int m = arr[1];

            int[,] matrix = new int[n, m];
            FillUp(matrix);




            while (true)
            {
                string[] arr1 = Console.ReadLine().Split().ToArray();

                if (arr1[0] == "Bloom")
                {
                    break;
                }

                int row = int.Parse(arr1[0]);
                int col = int.Parse(arr1[1]);

                try
                {
                    var position = new Position(row, col, n);

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                BloomingFlowers(matrix, row, col);
               
            }
            PrintMatrix(matrix);
        }

        private static void BloomingFlowers(int[,] matrix, int row, int col)
        {
            for (int col1 = 0; col1 < matrix.GetLength(0); col1++)
            {
                if (col != col1)
                {
                    matrix[row, col1] += 1;
                }
                else
                {
                    matrix[row, col1] = 1;
                }

            }

            for (int row1 = 0; row1 < matrix.GetLength(1); row1++)
            {
                if (row != row1)
                {
                    matrix[row1, col] += 1;
                }
                else
                {
                    matrix[row1, col] = 1;
                }

            }
        }
        private static void FillUp(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}