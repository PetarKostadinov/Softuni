using System;
using System.Linq;

namespace Stack
{
   public class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                string[] tokens = commandInput.Split(new string[] { " ", ","}, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Push")
                {
                    foreach (var item in tokens.Skip(1))
                    {
                        stack.Push(int.Parse(item));
                    }
                }
                else if (command == "Pop")
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                       stack.Pop();
                    }
                }

                commandInput = Console.ReadLine();
            }
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
        }
    }
}
