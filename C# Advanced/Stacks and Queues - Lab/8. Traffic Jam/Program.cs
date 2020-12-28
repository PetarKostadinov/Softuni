using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            Queue<string> queueSave = new Queue<string>();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "end")
                {
                    break;
                }
                if (comand == "green")
                {
                    if (queue.Count < count)
                    {
                        count = queue.Count;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        queueSave.Enqueue(queue.Dequeue());

                    }
                    continue;
                }

                queue.Enqueue(comand);
            }

            foreach (var item in queueSave)
            {
                Console.WriteLine($"{item} passed!");
            }
            Console.WriteLine($"{queueSave.Count} cars passed the crossroads.");
        }
    }
}
