using System;
using System.Collections.Generic;
using System.Linq;

namespace orderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> myDic = new Dictionary<string, List<int>>();
            List<string> people = Console.ReadLine().Split().ToList();

            while (true)
            {
                if (people[0] == "End")
                {
                    break;
                }

                myDic.Add(people[0], new List<int>() { int.Parse(people[1]), int.Parse(people[2]) });

                people = Console.ReadLine().Split().ToList();
            }

            foreach (var kvp in myDic.OrderBy(x => x.Value[1]))
            {
                Console.WriteLine($"{kvp.Key} with ID: {kvp.Value[0]} is {kvp.Value[1]} years old.");
            }
			
			    foreach (var kvp in myDic.OrderBy(x => x.Value[1]))
            {
                Console.WriteLine($"{kvp.Key} with ID: {kvp.Value[0]} is {kvp.Value[1]} years old.");
            }

        }
    }
}