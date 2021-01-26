using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int> minFunc = inputNumbers =>
            {
                int minValue = int.MaxValue;

                foreach (var currNum in inputNumbers)
                {
                    if (currNum < minValue)
                    {
                        minValue = currNum;
                    }
                }

                return minValue;
            };

            int[] numbers = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();

            int result = minFunc(numbers);

            Console.WriteLine(result);
        }
    }
}
