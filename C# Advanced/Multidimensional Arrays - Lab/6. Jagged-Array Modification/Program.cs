using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var jagedArr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jagedArr[i] = numbers;
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                var comands = input.Split(' ');

                string currCommand = comands[0];
                int row = int.Parse(comands[1]);
                int col = int.Parse(comands[2]);
                int value = int.Parse(comands[3]);

                if (row < 0 
                    || row > jagedArr.Length - 1 
                    || col < 0 
                    || col > jagedArr[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (currCommand == "Add")
                {
                    jagedArr[row][col] += value;
                }
                else if (currCommand == "Subtract")
                {
                    jagedArr[row][col] -= value;
                }
            }

            foreach (var array in jagedArr)
            {
                Console.WriteLine(string.Join(" ", array));

            }
        }
    }
}
