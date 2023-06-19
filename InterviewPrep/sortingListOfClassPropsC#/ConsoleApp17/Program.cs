using System;

namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string AgeGroup { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            // Creating a list of Person objects
            List<Person> people = new List<Person>()
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 20 }
        };

            // Sorting the list of people based on age in ascending order
            people.Sort((p1, p2) => p1.Age.CompareTo(p2.Age));

            // Displaying the sorted list of people
            Console.WriteLine("Sorted People by Age:");
            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            // Adding a new property to each person object
            foreach (var person in people)
            {
                person.AgeGroup = GetAgeGroup(person.Age);
            }

            // Displaying the updated list of people with the new property
            Console.WriteLine("\nPeople with Age Group:");
            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Age Group: {person.AgeGroup}");
            }
        }

        public static string GetAgeGroup(int age)
        {
            if (age <= 20)
                return "Youth";
            else if (age > 20 && age <= 30)
                return "Adult";
            else
                return "Senior";
        }
    }

}
