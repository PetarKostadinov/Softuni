namespace _07.Balanced_Parentheses
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var parantheses = Console.ReadLine()
                .Trim()
                .ToCharArray();

            var stack = new Stack<char>();
            var parenthesesPair = new Dictionary<char, char>();
            parenthesesPair['{'] = '}';
            parenthesesPair['['] = ']';
            parenthesesPair['('] = ')';

            if (parantheses.Length % 2 != 0 || parantheses.Length == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (var p in parantheses)
            {
                //open parantheses
                if (parenthesesPair.ContainsKey(p))
                {
                    stack.Push(p);
                }
                else
                {
                    var openParantheses = stack.Pop();
                    if (parenthesesPair[openParantheses] != p)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}