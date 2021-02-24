using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var arguments = Console.ReadLine().Split();
                try
                {
                    var personData = new Person(arguments[0], arguments[1], int.Parse(arguments[2]), decimal.Parse(arguments[3]));
                    persons.Add(personData);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            var parcentage = decimal.Parse(Console.ReadLine());
           persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

        }
    }
}
