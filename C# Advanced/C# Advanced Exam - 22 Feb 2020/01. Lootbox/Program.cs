using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.
                ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Queue<int> first = new Queue<int>(input1);
            Stack<int> second = new Stack<int>(input2);

            int collection = 0;

            while (first.Count != 0 && second.Count != 0)
            {
                int sum = first.Peek() + second.Peek();

                if (sum % 2 == 0)
                {
                    collection += sum;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }
            }
            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collection}");
            }
        }
    }
}