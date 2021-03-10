using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double litersPerKm, double airConditionerModifire)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.AirConditionerModifire = airConditionerModifire;
        }
        public double AirConditionerModifire { get; private set; }
        public double FuelQuantity { get; private set; }
        public double LitersPerKm { get; private set; }

        public virtual void Drive(double distance)
        {
            if ((this.LitersPerKm + AirConditionerModifire) * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= (this.LitersPerKm + AirConditionerModifire) * distance;

                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }

        }

        public virtual void Refuel(double givenAmountFuel)
        {
            this.FuelQuantity += givenAmountFuel;
        }
    }
}
