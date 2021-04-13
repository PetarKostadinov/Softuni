using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            var dimensions = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Queue<int> rowAndCol = new Queue<int>(dimensions);

            FillUp(matrix);

            var countOfships = PlayersCount(matrix);

            int firstPlayerCount = countOfships[0];
            int secondPlayerCont = countOfships[1];
            int totalCountShipsDestroyed = 0;
            int counter = 0;
            while (rowAndCol.Count > 0)
            {
                counter++;
                int row = rowAndCol.Dequeue();
                int col = rowAndCol.Dequeue();
                if (IsValid(matrix, row, col))
                {

                    if (matrix[row, col] == '#')
                    {
                        CheckForMineAndExplode(matrix,
                                               ref firstPlayerCount,
                                               ref secondPlayerCont,
                                               ref totalCountShipsDestroyed,
                                               row,
                                               col);
                    }
                    else if (matrix[row, col] == '<' && counter % 2 == 0)
                    {
                        firstPlayerCount--;
                        totalCountShipsDestroyed++;
                        matrix[row, col] = 'X';
                    }
                    else if (matrix[row, col] == '>' && counter % 2 != 0)
                    {
                        secondPlayerCont--;
                        totalCountShipsDestroyed++;
                        matrix[row, col] = 'X';
                    }

                    // Print(matrix);
                    if (firstPlayerCount == 0)
                    {
                        Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                        return;
                    }
                    if (secondPlayerCont == 0)
                    {
                        Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                        return;
                    }
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerCount} ships left. Player Two has {secondPlayerCont} ships left.");
        }

        private static void CheckForMineAndExplode(char[,] matrix,
                                                   ref int firstPlayerCount, 
                                                   ref int secondPlayerCont, 
                                                   ref int totalCountShipsDestroyed, 
                                                   int row,
                                                   int col)
        {
            matrix[row, col] = 'X';
            if (IsValid(matrix, row - 1, col - 1))
            {
                if (matrix[row - 1, col - 1] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row - 1, col - 1] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row - 1, col - 1] = 'X';
            }
            if (IsValid(matrix, row - 1, col))
            {
                if (matrix[row - 1, col] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row - 1, col] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row - 1, col] = 'X';
            }
            if (IsValid(matrix, row - 1, col + 1))
            {
                if (matrix[row - 1, col + 1] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row - 1, col + 1] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row - 1, col + 1] = 'X';
            }
            if (IsValid(matrix, row, col + 1))
            {
                if (matrix[row, col + 1] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row, col + 1] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row, col + 1] = 'X';
            }
            if (IsValid(matrix, row + 1, col + 1))
            {
                if (matrix[row + 1, col + 1] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row + 1, col + 1] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row + 1, col + 1] = 'X';
            }
            if (IsValid(matrix, row + 1, col))
            {
                if (matrix[row + 1, col] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row + 1, col] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row + 1, col] = 'X';
            }
            if (IsValid(matrix, row + 1, col - 1))
            {
                if (matrix[row + 1, col - 1] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row + 1, col - 1] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row + 1, col - 1] = 'X';
            }
            if (IsValid(matrix, row, col - 1))
            {
                if (matrix[row, col - 1] == '<')
                {
                    firstPlayerCount--;
                    totalCountShipsDestroyed++;
                }
                if (matrix[row, col - 1] == '>')
                {
                    secondPlayerCont--;
                    totalCountShipsDestroyed++;
                }
                matrix[row, col - 1] = 'X';
            }
        }

        public static void FillUp(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList();


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

        static bool IsValid(char[,] matrix, int row, int col)
        {
            var checkIsCorect = row >= 0
                             && row < matrix.GetLength(0)
                             && col >= 0
                             && col < matrix.GetLength(1) ? true : false;

            if (checkIsCorect == true)
            {
                return true;
            }
            return false;
        }

        static int[] PlayersCount(char[,] matrix)
        {
            int counterFirst = 0;
            int counterSecond = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        counterFirst++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        counterSecond++;
                    }
                }
            }
            return new int[] { counterFirst, counterSecond };
        }
    }
}
