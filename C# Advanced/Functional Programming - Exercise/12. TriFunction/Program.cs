using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int, bool> isEqualOrLargerFunc = (word, criteria) => word
            .Sum(x => x) >= criteria;

            int targetSum = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine()
                .Split()
                .ToArray();

            Func<string[], Func<string, int, bool>, string> myFunc = (names, isLargerFunc) => names
            .FirstOrDefault(x => isEqualOrLargerFunc(x, targetSum));

            string targetName = myFunc(inputNames, isEqualOrLargerFunc);

            Console.WriteLine(targetName);
        }
    }
}
