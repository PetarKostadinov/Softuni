using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().ToArray();

            Queue<string> que = new Queue<string>();

            Queue<int> result = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = int.Parse(numbers[i]);

                if (num % 2 == 0)
                {
                    result.Enqueue(num);
                }
            }     

                Console.WriteLine(string.Join(", ", result));
            
        }
    }
}
