using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            bool isFound = false;

            for (int curr = 0; curr < arr.Length; curr++)
            {
                int rightSum = 0;

                for (int i = curr + 1; i < arr.Length; i++)
                {
                    rightSum += arr[i];
                }

                int leftSum = 0;

                for (int j = curr - 1; j >= 0; j--)
                {
                    leftSum += arr[j];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(curr);

                    isFound = true;
                    break;
                }
            }
            if ( ! isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
