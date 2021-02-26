using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string backingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechType, double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = bakingTechType;
            this.Weight = weight;

        }
        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (!DoughValidator.IsValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BackingTechnique
        {
            get
            {
                return backingTechnique;
            }
            set
            {
                if (!DoughValidator.IsValidBackingTechnique(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                backingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return this.Weight * 2
                               * DoughValidator.GetBackingTechModifire(this.backingTechnique)
                               * DoughValidator.GetFlourModifire(this.flourType);
        }
    }
}
