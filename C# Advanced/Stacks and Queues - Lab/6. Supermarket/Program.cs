using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            Queue<string> queuePeople = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Paid")
                {
                    foreach (var item in queue)
                    {
                        queuePeople.Enqueue(item);
                       
                    }
                    queue.Clear();
                    continue;
                }
                if (input == "End")
                {
                    break;
                }

                queue.Enqueue(input);
            }
            foreach (var item in queuePeople)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
