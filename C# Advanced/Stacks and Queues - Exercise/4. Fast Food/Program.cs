using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());

            var clients = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(clients);

            int count = clients.Length;

            Console.WriteLine(queue.Max());

            for (int i = 0; i < count; i++)
            {
                if (queue.Peek() <= total)
                {
                    total -= queue.Peek();

                    queue.Dequeue();

                }
            }
               

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: " + string.Join(" ", queue));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
