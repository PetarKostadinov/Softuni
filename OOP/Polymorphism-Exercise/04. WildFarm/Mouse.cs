using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifire = 0.10;
        private static HashSet<string> mouseAlowedFood = new HashSet<string> 
        { 
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name,
            double weight,
            string livingRegion) 
            : base(name, 
                  weight,
                  mouseAlowedFood,
                  BaseWeightModifire,
                  livingRegion)
        {

        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
