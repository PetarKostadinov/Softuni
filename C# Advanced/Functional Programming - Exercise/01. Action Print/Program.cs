using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
