using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jagedArray[row] = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
            }

            Analyze(jagedArray);

            string comand = Console.ReadLine();

            while (comand != "End")
            {
                string[] comandInfo = comand.Split();

                int targetRow = int.Parse(comandInfo[1]);
                int targetCol = int.Parse(comandInfo[2]);
                int value = int.Parse(comandInfo[3]);

                if (!isInside(jagedArray, targetRow, targetCol))
                {
                    comand = Console.ReadLine();
                    continue;
                }

                if (comandInfo[0] == "Add")
                {
                    jagedArray[targetRow][targetCol] += value; 
                }
                else
                {
                    jagedArray[targetRow][targetCol] -= value;
                }

                comand = Console.ReadLine();
            }

            foreach (var row in jagedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool isInside(double[][] jagedArray, int targetRow, int targetCol)
        {
            return targetRow >= 0
                && targetRow < jagedArray.Length
                && targetCol >= 0
                && targetCol < jagedArray[targetRow].Length;
        }

        private static void Analyze(double[][] jagedArray)
        {
            for (int row = 0; row < jagedArray.Length - 1; row++)
            {
                if (jagedArray[row].Length == jagedArray[row + 1].Length)
                {
                    for (int col = 0; col < jagedArray[row].Length; col++)
                    {
                        jagedArray[row][col] *= 2;
                        jagedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagedArray[row].Length; col++)
                    {
                        jagedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jagedArray[row + 1].Length; col++)
                    {
                        jagedArray[row + 1][col] /= 2;
                    }
                }
            }
        }
    }
}
