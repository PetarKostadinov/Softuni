using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            Stack<string> stack = new Stack<string>();

            stack.Push(sb.ToString());

            for (int i = 0; i < count; i++)
            {
                var comands = Console.ReadLine().Split().ToArray();

                string currComand = comands[0];

                if (currComand == "1")
                {
                    string letters = comands[1];

                    sb.Append(letters);

                    stack.Push(sb.ToString());
                }
                else if (currComand == "2")
                {
                    int numbersToErase = int.Parse(comands[1]);

                    sb.Remove(sb.Length - numbersToErase, numbersToErase);
                   
                    stack.Push(sb.ToString());

                }
                else if (currComand == "3")
                {
                    int positionToShow = int.Parse(comands[1]);

                    Console.WriteLine(sb.ToString()[positionToShow - 1]);
                }
                else if (currComand == "4")
                {
                   sb.Clear();
                    stack.Pop();
                    sb.Append(stack.Peek());
                }
            }
        }
    }
}
