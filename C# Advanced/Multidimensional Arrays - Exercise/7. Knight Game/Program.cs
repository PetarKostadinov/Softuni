using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoerd = new char[n, n];

            FillUpMatrix(chessBoerd);

            int countRepleced = 0;

            int rowKiller = 0;
            int colKiller = 0;

            while (true)
            {
                int maxAtacks = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currSimbol = chessBoerd[row, col];

                        int countAtacks = 0;

                        if (currSimbol == 'K')
                        {
                            countAtacks = GetAtacks(chessBoerd, row, col, countAtacks);

                            if (countAtacks > maxAtacks)
                            {
                                maxAtacks = countAtacks;
                                rowKiller = row;
                                colKiller = col;
                            }
                        }
                    }
                }
                if (maxAtacks > 0)
                {
                    chessBoerd[rowKiller, colKiller] = '0';
                    countRepleced++;
                }
                else
                {
                    Console.WriteLine(countRepleced);

                    break;
                }

            }
        }

        private static int GetAtacks(char[,] chessBoerd, int row, int col, int countAtacks)
        {
            if (IsInside(chessBoerd, row - 2, col + 1) && chessBoerd[row - 2, col + 1] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row - 2, col - 1) && chessBoerd[row - 2, col - 1] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row + 1, col + 2) && chessBoerd[row + 1, col + 2] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row + 1, col - 2) && chessBoerd[row + 1, col - 2] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row - 1, col + 2) && chessBoerd[row - 1, col + 2] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row - 1, col - 2) && chessBoerd[row - 1, col - 2] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row + 2, col - 1) && chessBoerd[row + 2, col - 1] == 'K')
            {
                countAtacks++;
            }

            if (IsInside(chessBoerd, row + 2, col + 1) && chessBoerd[row + 2, col + 1] == 'K')
            {
                countAtacks++;
            }

            return countAtacks;
        }

        public static void FillUpMatrix(char[,] num)
        {
            for (int row = 0; row < num.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < num.GetLength(1); col++)
                {
                    num[row, col] = currRow[col];
                }
            }
        }
        private static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 
                && targetRow < chessBoard.GetLongLength(0)
                && targetCol >= 0 
                && targetCol < chessBoard.GetLength(1);

        }
    }
}
