using System;

namespace Algorithms_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            Console.WriteLine(Factorial(num));
        }

        public static long Factorial(long n)
        {
            if (n == 0) // base case
            {
                return 1;
            }
           return n * Factorial(n - 1);    // Recursion
        }

        // 5! = 5 * 4!
        // 4! = 4 * 3!
        // 3! = 3 * 2!
        // 2! = 2 * 1!
        // 1! = 1 * 0!
        // 0! = 1

        // n! = n * (n - 1)!
    }
}
