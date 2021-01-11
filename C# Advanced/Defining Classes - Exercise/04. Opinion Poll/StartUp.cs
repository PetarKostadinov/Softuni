using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> collection = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person human = new Person(name, age);

                collection.Add(human);
                
            }

            foreach (var item in collection.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
           
        }

    }
}
