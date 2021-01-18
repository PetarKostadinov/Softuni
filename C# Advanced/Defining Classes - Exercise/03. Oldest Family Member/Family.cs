using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
   public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }
      
        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public  Person GetOldestMember()
        {
            int maxValue = int.MinValue;

            foreach (var member in People)
            {
                if (member.Age > maxValue)
                {
                    maxValue = member.Age;

                }
            }
            
            return People.FirstOrDefault(x => x.Age == maxValue);
            //Person oldest = this.People.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
