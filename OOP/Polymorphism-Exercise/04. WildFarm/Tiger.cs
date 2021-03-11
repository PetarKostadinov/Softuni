using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {

        private const double BaseWeightModifire = 1.00;
        private static HashSet<string> tigerAlowedFood = new HashSet<string>
        {
            nameof(Meat)
       
        };

        public Tiger(string name,
            double weight,
            string livingRegion, 
            string breed) 
            : base(name,
                  weight, 
                  tigerAlowedFood,
                  BaseWeightModifire,
                  livingRegion, 
                  breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
