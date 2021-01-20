using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> data = 
                new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0].Equals("Revision"))
                {
                    break;
                }

                if (!data.ContainsKey(input[0]))
                {
                    data.Add(input[0], new Dictionary<string, double>());
                    data[input[0]].Add(input[1], double.Parse(input[2]));
                }
                else
                {
                    data[input[0]].Add(input[1], double.Parse(input[2]));
                }
            }

            foreach (var shop in data.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
