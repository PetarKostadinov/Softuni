using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentification> population = new List<IIdentification>(); 

            while (true)
            {
                var data = Console.ReadLine().Split().ToList();

                if (data[0] == "End")
                {
                    break;
                }

                if (data.Count == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    population.Add(new Citizens(name, age, id));
                }
                else if (data.Count == 2)
                {
                    string model = data[0];
                    string id = data[1];

                    population.Add(new Robots(model, id));
                }
            }
            string endingDigits = Console.ReadLine();

            foreach (var id in population.Where(x => x.Id.EndsWith(endingDigits)))
            {
                Console.WriteLine(id.Id);
            }
        }
    }
}
