using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] givenTasks = Console.ReadLine()
                              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();
                              
            Stack<int> tasks = new Stack<int>(givenTasks);

            int[] givenTreads = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            Queue<int> threads = new Queue<int>(givenTreads);

            int target = int.Parse(Console.ReadLine());

            while (true)
            {
                if (threads.Peek() >= tasks.Peek())
                {
                    if (tasks.Peek() == target)
                    {
                        break;
                    }

                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    if (tasks.Peek() == target)
                    {
                        break;
                    }

                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {target}");

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
