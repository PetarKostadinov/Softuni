using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ").ToArray();


            Queue<string> queue = new Queue<string>(songs);

            while (true)
            {


                if (queue.Count() == 0)
                {
                    Console.WriteLine("No more songs!");
                    return;
                }

                var comands = Console.ReadLine().Split("d ").ToArray();
                string currComand = comands[0];

                if (currComand == "Play")
                {
                    queue.Dequeue();
                }
                else if (currComand == "Ad")
                {
                    string song = comands[1];

                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (currComand == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));

                   
                }
            }
        }
    }
}
