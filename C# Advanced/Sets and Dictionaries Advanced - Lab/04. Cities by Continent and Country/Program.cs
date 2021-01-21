using System;
using System.Collections.Generic;

namespace Cities_byContinentCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> result = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!result.ContainsKey(continent))
                {
                    result.Add(continent, new Dictionary<string, List<string>>());

                    if (!result[continent].ContainsKey(country))
                    {
                        result[continent].Add(country, new List<string>());

                        result[continent][country].Add(city);
                    }
                    else
                    {
                        result[continent][country].Add(city);
                    }
                }
                else
                {
                    if (!result[continent].ContainsKey(country))
                    {
                        result[continent].Add(country, new List<string>());

                        result[continent][country].Add(city);
                    }
                    else
                    {
                        result[continent][country].Add(city);
                    }
                }
            }
            foreach (var continent in result)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
