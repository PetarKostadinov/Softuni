using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICitizen> animals = new List<ICitizen>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split().ToList();

                if (data.Count == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthdate = data[3];

                    animals.Add(new Citizens(name, age, id, birthdate));
                }
                else if (data.Count == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    animals.Add(new Rebel(name, age, group));

                }
            }
            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (animals.Any(x => x.Name == name))
                {
                    var buyer = animals.FirstOrDefault(x => x.Name == name);

                    buyer.BuyFood();
                }
            }

            Console.WriteLine(animals.Sum(x => x.Food));
        }
    }
}
