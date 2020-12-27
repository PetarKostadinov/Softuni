using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            Queue<string> queue = new Queue<string>(input);

            int count = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Peek()}");
                queue.Dequeue();
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
