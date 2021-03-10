using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirconditionerModifire = 0.9;
        public Car(double fuelQuantity, double litersPerKm) 
            : base(fuelQuantity, litersPerKm, CarAirconditionerModifire)
        {
            
        }


        public override void Refuel(double givenAmountFuel)
        {
            base.Refuel(givenAmountFuel);
        }


    }
}
