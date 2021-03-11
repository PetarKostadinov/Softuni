using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name,
            double weight,
            HashSet<string> alowedFood,
            double wieghtModifire,
            double wingSize)
            : base(name,
                  weight,
                  alowedFood,
                  wieghtModifire)
        {
            this.WingSize = wingSize;

        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
