using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var input2 = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            Stack<int> bottles = new Stack<int>();
            Queue<int> cups = new Queue<int>();

            int wasted = 0;
            int leftForRefill = 0;

            foreach (var cup in input1)
            {
                cups.Enqueue(cup);

            }
            foreach (var bottle in input2)
            {
                bottles.Push(bottle);
            }

            while (true)
            {
                if (cups.Count == 0 || bottles.Count == 0)
                {
                    break;
                }

                int currBottle = bottles.Pop();
                int currCup = cups.Peek();

                if (currBottle >= currCup)
                {
                    wasted += currBottle - currCup;
                    cups.Dequeue();
                }
                else
                {
                    leftForRefill = currCup - currBottle;

                    while (leftForRefill > 0)
                    {
                        int nextBottle = bottles.Pop();

                        if (nextBottle >= leftForRefill)
                        {
                            wasted += nextBottle - leftForRefill;
                            cups.Dequeue();
                            break;
                        }
                        else
                        {

                            leftForRefill -= nextBottle;
                        }

                    }
                  
                }
            }

            if (cups.Count == 0)
            {

                Console.Write("Bottles:" + " ");

                foreach (var bottle in bottles)
                {
                    Console.Write(string.Join(" ", bottle));
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
            else
            {
                Console.Write("Cups:" + " ");
                foreach (var cup in cups)
                {
                    Console.Write(string.Join(" ", cup + " "));
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
        }
    }
}
