using System;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                box.Value.Add(input);
            }
            string targetItem = Console.ReadLine();
            int result = box.isGreaterThan(targetItem);
            Console.WriteLine(result);
        }
    }
}
