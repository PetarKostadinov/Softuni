using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine();

                names.Add(input);
            }

            foreach (var name  in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
