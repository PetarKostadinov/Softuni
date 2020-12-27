using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();

            Stack<string> stack = new Stack<string>(input);


            while (stack.Count > 1)
            {

                int first = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (sign)
                {
                    case "+":stack.Push((first + second).ToString());  
                    break;

                    case "-": stack.Push((first - second).ToString());
                        break;
                }
                
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
