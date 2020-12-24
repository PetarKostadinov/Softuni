using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfarays = int.Parse(Console.ReadLine());

            int[] firstFromLeft = new int[numberOfarays];

            int[] firstFromRight = new int[numberOfarays];
                

            for (int i = 0; i < numberOfarays; i++)
            {
                int[] curr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstFromLeft[i] = curr[0];
                    firstFromRight[i] = curr[1];
                }
                else
                {
                    firstFromLeft[i] = curr[1];
                    firstFromRight[i] = curr[0];
                }
            }

           
                Console.WriteLine(string.Join(" ", firstFromLeft));
            Console.WriteLine(string.Join(" ", firstFromRight));
            
        }
    }
}
