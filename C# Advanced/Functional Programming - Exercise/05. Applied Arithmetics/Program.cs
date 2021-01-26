using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int> subtractFunc = num => num -= 1;
            Func<int, int> multiplyFunc = num => num *= 2;
            Func<int, int> addFunc = num => num += 1;

            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            string comand = Console.ReadLine();

            while (comand != "end")
            {
                if (comand == "add")
                {
                    numbers = numbers.Select(addFunc).ToArray();
                }
                else if (comand == "multiply")
                {
                    numbers = numbers.Select(multiplyFunc).ToArray();
                }
                else if (comand == "subtract")
                {
                    numbers = numbers.Select(subtractFunc).ToArray();
                }
                else if (comand == "print")
                {
                    print(numbers);
                }

                comand = Console.ReadLine();
            }
        }
    }
}
