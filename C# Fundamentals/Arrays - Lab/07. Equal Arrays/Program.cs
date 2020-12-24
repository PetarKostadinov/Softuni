using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrOne = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            int[] arrTwo = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();



            for (int i = 0; i < arrOne.Length; i++)
            {
               
                if (arrOne[i] != arrTwo[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }

            }

            int sum = arrOne.Sum();

            Console.WriteLine($"Arrays are identical. Sum: {sum}");

        }
    }
}
