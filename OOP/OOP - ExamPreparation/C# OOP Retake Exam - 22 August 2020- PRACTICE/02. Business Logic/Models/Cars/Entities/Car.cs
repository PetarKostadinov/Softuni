using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private int minHorsePower;
        private int maxHorsePower;
        private string model;
        private int horsePower;
       
        

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
          
        }

        public string Model  
        {
            get 
            {
                return this.model;
            }
            private set
            {

                if (value.Length < 4 || string.IsNullOrWhiteSpace(value))
                {

                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }

        public int HorsePower 
        {
            get
            {
                return this.horsePower;
            }
            private set
            {

                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var result = this.CubicCentimeters / this.HorsePower * laps;

            return result;
        }
    }
}
