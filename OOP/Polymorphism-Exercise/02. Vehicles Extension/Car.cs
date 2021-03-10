using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirconditionerModifire = 0.9;
        public Car(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity, AirconditionerModifire)
        {
            
        }


        public override void Refuel(double givenAmountFuel)
        {
            base.Refuel(givenAmountFuel);
        }


    }
}
