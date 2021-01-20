using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, double> result = new Dictionary<double, double>();
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!result.ContainsKey(input[i]))
                {
                    counter = 1;
                    result.Add(input[i], counter);
                }
                else
                {
                    result[input[i]] += 1;
                }

            }
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
            
        }
    }
}
