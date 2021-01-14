using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                var comand = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (comand[0] == 1)
                {
                    stack.Push(comand[1]);
                }
                else if (comand[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }

                }
                else if (comand[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (comand[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
