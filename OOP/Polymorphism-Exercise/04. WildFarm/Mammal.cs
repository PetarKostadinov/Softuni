using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name,
            double weight,
            HashSet<string> alowedFood,
            double wieghtModifire,
            string livingRegion)
            : base(name,
                  weight,
                  alowedFood,
                  wieghtModifire)
        {
            this.LivingRegion = livingRegion;

        }

        public string LivingRegion { get; private set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
