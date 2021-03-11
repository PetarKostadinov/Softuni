using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifire = 0.40;
        private static HashSet<string> dogAlowedFood = new HashSet<string>
        {
            nameof(Meat)
           
        };

        public Dog(string name,
            double weight,
            string livingRegion)
            : base(name,
                  weight,
                  dogAlowedFood,
                  BaseWeightModifire,
                  livingRegion)
        {

        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
