using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerModifire = 1.6;
        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity, AirConditionerModifire)
        {

        }

        public override void Refuel(double givenAmountFuel)
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
                this.FuelQuantity += givenAmountFuel * 0.95;
            }
        }
    }
}
