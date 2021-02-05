using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
 
       
    public class Program
    {
      
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToArray();

            int n = dimensions[0];

            int[,] garden = new int[n, n];

            FillUpGarden(garden);

            Queue<List<int>> flowers = new Queue<List<int>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Bloom Bloom Plow")
                {
                    break;
                }

                var comands = input.Split()
                                   .Select(int.Parse)
                                   .ToArray();

                int row = comands[0];
                int col = comands[1];

                bool isValid = row >= 0
                            && row < garden.GetLength(0)
                            && col >= 0
                            && col < garden.GetLength(1)
                            ? true : false;

                if (isValid)
                {
                    List<int> flower = new List<int>();
                    flower.Add(row);
                    flower.Add(col);

                    flowers.Enqueue(flower);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            while (flowers.Count > 0)
            {
                var output = flowers.Dequeue();

                var row = output[0];
                var col = output[1];

                for (int i = 0; i < n; i++)
                {
                    garden[row, i] += 1;
                }
                
                for (int j = 0; j < n; j++)
                {
                    if (j == row)
                    {
                        continue;
                    }
                    garden[j, row] += 1;
                }
            }
            Print(garden);
        }
 
        private static void FillUpGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }
        }
        private static void Print(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
