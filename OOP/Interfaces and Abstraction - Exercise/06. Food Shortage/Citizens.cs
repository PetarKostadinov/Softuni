using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IIdentification, IBirthdates, IBuyer,ICitizen
    {
        public Citizens(string name, int age, string id, string birthdate)
        { 
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
