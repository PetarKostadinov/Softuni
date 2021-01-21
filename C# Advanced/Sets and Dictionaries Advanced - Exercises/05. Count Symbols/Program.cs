using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> collection = new SortedDictionary<char, int>();

            int counter = 0;

            foreach (var item in input)
            {
                if (!collection.ContainsKey(item))
                {
                    counter = 1;
                    collection.Add(item, counter);
                }
                else
                {
                    collection[item] += 1;
                }
            }
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
