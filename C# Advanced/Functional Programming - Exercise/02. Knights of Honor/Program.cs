using System;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = names => Console.WriteLine($"Sir {names}");

            Console.ReadLine().Split().ToList().ForEach(print);

        }
    }
}
