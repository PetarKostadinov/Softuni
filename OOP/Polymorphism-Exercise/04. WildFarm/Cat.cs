using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {

        private const double BaseWeightModifire = 0.30;
        private static HashSet<string> catAlowedFood = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)


        };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name,
                  weight,
                  catAlowedFood, 
                  BaseWeightModifire,
                  livingRegion,
                  breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
