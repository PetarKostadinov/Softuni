using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            SortedSet<string> collection = new SortedSet<string>();

            for (int i = 0; i < N ; i++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in elements)
                {
                    collection.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", collection));
          
        }
    }
}
