using System;
using System.Numerics;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger[][] pascalTRiangle = new BigInteger[n][];

            for (int i = 0; i < pascalTRiangle.Length; i++)
            {
                pascalTRiangle[i] = new BigInteger[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                pascalTRiangle[i][0] = 1;
                pascalTRiangle[i][pascalTRiangle[i].Length - 1] = 1;

                for (int j = 1; j < pascalTRiangle[i].Length - 1; j++)
                {
                    pascalTRiangle[i][j] = pascalTRiangle[i - 1][j] + pascalTRiangle[i - 1][j - 1];

                }
            }

            foreach (var array in pascalTRiangle)
            {
                foreach (var number in array)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

