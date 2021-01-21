using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsofElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int first = nums[0];
            int second = nums[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < first; i++)
            {
                int num = int.Parse(Console.ReadLine());

                firstSet.Add(num);
            }

            for (int i = 0; i < second; i++)
            {
                int num = int.Parse(Console.ReadLine());

                secondSet.Add(num);
            }

            foreach (var num1 in firstSet)
            {
                foreach (var num2 in secondSet)
                {
                    if (num1 == num2)
                    {
                        Console.Write(num1 + " ");
                    }
                  
                }
            }
        }
    }
}
