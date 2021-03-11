using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double BaseWeightModifire = 0.35;
        private static HashSet<string> henAlowedFood = new HashSet<string> 
        { 
            nameof(Meat),
            nameof(Vegetable), 
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name,
            double weight,
            double wingSize)
            : base(name,
                weight,
                henAlowedFood,
                BaseWeightModifire,
                wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
