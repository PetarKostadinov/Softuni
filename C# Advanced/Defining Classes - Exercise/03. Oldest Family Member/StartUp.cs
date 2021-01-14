using System;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            Family newFamily = new Family();

            for (int i = 0; i < N; i++)
            {
                var data = Console.ReadLine();
                var input = data.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = input[0];
                var age = int.Parse(input[1]);
                var newPerson = new Person(name, age);

                newFamily.AddMember(newPerson);
            }
            Console.WriteLine(newFamily.GetOldestMember());
        }
    }
}
