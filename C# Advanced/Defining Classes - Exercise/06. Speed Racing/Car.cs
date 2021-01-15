using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
   public class Car
    {
        //string Model
        // double FuelAmount
        // double FuelConsumptionPerKilometer
        // double Travelled distance

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model { get ; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(int amountOfKm)
        {
            if (amountOfKm * this.FuelConsumptionPerKilometer <= this.FuelAmount)
            {
                this.FuelAmount -= amountOfKm * this.FuelConsumptionPerKilometer;

                this.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        
        }
    }
}
