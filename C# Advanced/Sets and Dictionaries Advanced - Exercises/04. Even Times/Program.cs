using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Dictionary<int, int> collection = new Dictionary<int, int>();

            int counter = 0;

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!collection.ContainsKey(num))
                {
                    counter = 1;

                    collection.Add(num, counter);
                }
                else
                {
                    collection[num] += 1;
                }
            }

            foreach (var num in collection.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(num.Key);
            }
        }
    }
}
