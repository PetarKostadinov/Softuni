using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string[] comands = Console.ReadLine().ToLower().Split().ToArray();

                if (comands[0] == "end")
                {
                    break;
                }

                else if (comands[0] == "add")
                {
                    stack.Push(int.Parse(comands[1]));
                    stack.Push(int.Parse(comands[2]));
                }
                else if (comands[0] == "remove")
                {
                    int length = int.Parse(comands[1]);

                    if (length <= stack.Count)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            stack.Pop();
                        }
                    }
                   
                }

            }
            Console.WriteLine(stack.Sum());
        }
    }
}
