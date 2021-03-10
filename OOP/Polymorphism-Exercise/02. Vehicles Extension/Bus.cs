using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirconditionerModifire = 1.4;
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity, BusAirconditionerModifire)
        {
        }

        public void TurnOnAirconditioner()
        {
            this.AirConditionerModifire = BusAirconditionerModifire;
        }

        public void TurnOffAirconditioner()
        {
            this.AirConditionerModifire = 0;
        }
    }
}
