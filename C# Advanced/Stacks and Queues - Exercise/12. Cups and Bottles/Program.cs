﻿using System;
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

            Queue<int> cups = new Queue<int>(input1);
            Stack<int> bottles = new Stack<int>(input2);

            int wasted = 0;
            int leftForRefill = 0;

            while (true)
            {
                if (cups.Count == 0 || bottles.Count == 0)
                {
                    break;
                }

                int currBottle = bottles.Pop();
                int currCup = cups.Dequeue();

                if (currBottle >= currCup)
                {
                    wasted += currBottle - currCup;
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
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                 Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
                
            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
