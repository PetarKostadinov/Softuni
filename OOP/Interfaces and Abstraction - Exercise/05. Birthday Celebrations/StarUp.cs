using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdates> animals = new List<IBirthdates>(); 

            while (true)
            {
                var data = Console.ReadLine().Split().ToList();

                if (data[0] == "End")
                {
                    break;
                }

                if (data.Count == 5)
                {
                    string type = data[0];
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthdate = data[4];
                   
                    animals.Add(new Citizens(type, name, age, id, birthdate));
                }
                else if (data.Count == 3)
                {
                    string type = data[0];
                    string model = data[1];
                    string id = data[2];

                    if (type == "Pet")
                    {
                        string name = model;
                        string birthdate = id;
                    
                        animals.Add(new Pets(type, name, birthdate));
                    }
                }
            }
            string endingDigits = Console.ReadLine();

            foreach (var member in animals.Where(x => x.Birthdate.EndsWith(endingDigits)))
            {
                Console.WriteLine(member.Birthdate);
            }
        }
    }
}
