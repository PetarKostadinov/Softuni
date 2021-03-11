using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal 
    {
        protected Animal(string name, double weight, HashSet<string> alowedFood, double wieghtModifire)
        {
            this.Name = name;
            this.Weight = weight;
            this.AlowedFood = alowedFood;
            this.WeightModifire = wieghtModifire;
        }

        private double WeightModifire { get; set; }
        private HashSet<string> AlowedFood { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AlowedFood.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += this.WeightModifire * this.FoodEaten;
        
        }
    }
}
