using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (!ToppingValidator.IsValid(value))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double GetTotalCalories()
        {
            return 2 * this.Weight * ToppingValidator.GetModifire(this.Type);
        }
    }
}
