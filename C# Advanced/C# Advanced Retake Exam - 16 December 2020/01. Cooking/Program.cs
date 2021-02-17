using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine()
                       .Split(" ", StringSplitOptions
                       .RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToList();
            var second = Console.ReadLine()
                        .Split(" ", StringSplitOptions
                        .RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

            Queue<int> queueLiquid = new Queue<int>(first);
            Stack<int> stackIngredients = new Stack<int>(second);

            Dictionary<string, int> products = new Dictionary<string, int>();
            Dictionary<string, int> result = new Dictionary<string, int>();

            products.Add("Bread", 25);
            products.Add("Cake", 50);
            products.Add("Pastry", 75);
            products.Add("Fruit Pie", 100);

            result.Add("Bread", 0);
            result.Add("Cake", 0);
            result.Add("Pastry", 0);
            result.Add("Fruit Pie", 0);

            while (queueLiquid.Count != 0 && stackIngredients.Count != 0)
            {
                int liquid = queueLiquid.Peek();
                int ingredients = stackIngredients.Peek();

                int sum = liquid + ingredients;

                if (products.Values.Any(x => x == sum))
                {
                    foreach (var item in products)
                    {
                        if (item.Value == sum)
                        {
                            queueLiquid.Dequeue();
                            stackIngredients.Pop();
                            result[item.Key]++;
                            break;
                        }
                    }
                }
                else
                {
                    queueLiquid.Dequeue();
                    ingredients += 3;
                    stackIngredients.Pop();
                    stackIngredients.Push(ingredients);
                }
            }

            if (result.Values.All(x => x > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queueLiquid.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueLiquid)}");
            }

            if (stackIngredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", stackIngredients)}");
            }

            foreach (var kvp in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}

