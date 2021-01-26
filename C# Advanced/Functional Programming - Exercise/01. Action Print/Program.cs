using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = items => Console.WriteLine(items);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);

        }
    }
}
