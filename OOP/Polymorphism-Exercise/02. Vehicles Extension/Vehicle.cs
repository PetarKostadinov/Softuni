using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double litersPerKm,
                          double tankCapacity, double airConditionerModifire)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.AirConditionerModifire = airConditionerModifire;
        }
        protected double AirConditionerModifire { get; set; }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double LitersPerKm { get; private set; }

        public double TankCapacity { get; private set; }

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
            if (givenAmountFuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + givenAmountFuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {givenAmountFuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += givenAmountFuel;
            }
        }
    }
}
