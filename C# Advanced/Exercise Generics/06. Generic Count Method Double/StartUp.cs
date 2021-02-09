using System;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Value.Add(input);
            }
            double targetItem = double.Parse(Console.ReadLine());
            int result = box.isGreaterThan(targetItem);
            Console.WriteLine(result);
        }
    }
}
