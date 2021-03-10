using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double CarAirConditionerModifire = 1.6;
        public Truck(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm, CarAirConditionerModifire)
        {
           
        }

        public override void Refuel(double givenAmountFuel)
        {
            base.Refuel(givenAmountFuel * 0.95);
        }

    }
}
