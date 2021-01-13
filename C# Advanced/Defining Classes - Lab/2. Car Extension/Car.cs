using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        //private string make;
        //private string model;
        //private int year;

        public string Make { get; set; }
      
        public string Model { get; set; }
      
        public int Year { get; set; }

        public double FuelQuantity { get; set; }    //•	fuelQuantity: double  •	fuelConsumption: double

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double consumption = distance * FuelConsumption;

            if (this.FuelQuantity - consumption > 0)
            {
                FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }

        }
        public string WhoAmI()
        {
           return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
        }

         
    }
}
