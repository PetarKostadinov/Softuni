using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int nToPush = nsx[0];
            int sToPop = nsx[1];
            int xToLook = nsx[2];

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> stack = new Queue<int>();

            for (int i = 0; i < nToPush; i++)
            {
                stack.Enqueue(numbers[i]);
            }

            for (int i = 0; i < sToPop; i++)
            {
                stack.Dequeue();
            }


            if (stack.Contains(xToLook))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0 && !stack.Contains(xToLook))
            {


                Console.WriteLine(stack.Min());

            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }

        }
    }
}
