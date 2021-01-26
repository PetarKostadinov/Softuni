using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenPredicate = num => num % 2 == 0;

            Func<int, bool> isEvenFunc = myNum => myNum % 2 == 0;

            Action<List<int>> printNUmbers = nums => Console.WriteLine(string.Join(" ", nums));

            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();


            List<int> numbers = new List<int>();

            int startNum = input[0];
            int endNum = input[1];

            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            List<int> result = new List<int>();

            string numbersTipe = Console.ReadLine();

            if (numbersTipe == "even")
            {
                result = numbers.Where(isEvenFunc).ToList();
            }
            else
            {
                result = numbers.Where(x => !isEvenFunc(x)).ToList();
            }
            printNUmbers(result);
        }
    }
}
