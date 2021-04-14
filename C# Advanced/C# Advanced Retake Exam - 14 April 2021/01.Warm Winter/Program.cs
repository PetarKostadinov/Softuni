using System;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hatsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] scarfsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>(hatsInput);
            Queue<int> scarfs = new Queue<int>(scarfsInput);

            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else if (scarf < hat)
                {
                    sets.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
