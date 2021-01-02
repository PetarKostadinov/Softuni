using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(sequens);

            int capacity = int.Parse(Console.ReadLine());

            int shelf = 0;

            int sum = 0;

            while (stack.Count > 0)
            {
                var curent = stack.Peek();

                if (sum + curent > capacity)
                {
                    shelf++;
                    sum = 0;
                }
                else if (sum + curent == capacity)
                {
                    shelf++;
                    sum = 0;
                    stack.Pop();
                }
                else
                {
                    sum += stack.Pop();
                }
            }
            if (sum > 0)
            {
                shelf++;
            }

            Console.WriteLine(shelf);  
        }
    }
}
