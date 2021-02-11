using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
   public class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] personInfo = command.Split().ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                command = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            Person targetPerson = people[n - 1];

            int mathces = 1;

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0 && !person.Equals(targetPerson))
                {
                    mathces++;
                }
               
            }

            if (mathces == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{mathces} {people.Count - mathces} {people.Count}");
            }
        }
    }
}
