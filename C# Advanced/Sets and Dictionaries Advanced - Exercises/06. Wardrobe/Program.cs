using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> collection =
                   new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int counter = 0;

                string color = input[0];

                if (!collection.ContainsKey(color))
                {
                    collection.Add(color, new Dictionary<string, int>());

                    for (int p = 1; p < input.Length; p++)
                    {
                        if (!collection[color].ContainsKey(input[p]))
                        {
                            counter = 1;
                            collection[color].Add(input[p], counter);
                        }
                        else
                        {
                            collection[color][input[p]] += 1;
                        }
                    }
                }
                else
                {
                    for (int j = 1; j < input.Length; j++)
                    {
                        if (!collection[color].ContainsKey(input[j]))
                        {
                            counter = 1;
                            collection[color].Add(input[j], counter);
                        }
                        else
                        {
                            collection[color][input[j]] += 1;
                        }
                    }
                }
            }

            var faind = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string colorToLook = faind[0];
            string itemToLook = faind[1];

            foreach (var color in collection)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (item.Key == itemToLook && color.Key == colorToLook)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                    
                }
            }
        }
    }
}
