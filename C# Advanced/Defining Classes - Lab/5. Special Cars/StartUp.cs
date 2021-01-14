using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("No more tires"))
                {
                    break;
                }

                string[] tireInfo = command.Split();

                Tire[] currTires = new Tire[4]
                {
                new Tire(int.Parse(tireInfo[0]),double.Parse(tireInfo[1])),
                new Tire(int.Parse(tireInfo[2]),double.Parse(tireInfo[3])),
                new Tire(int.Parse(tireInfo[4]),double.Parse(tireInfo[5])),
                new Tire(int.Parse(tireInfo[6]),double.Parse(tireInfo[7]))
                };

                tires.Add(currTires);
            }

            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("Engines done"))
                {
                    break;
                }

                string[] engineInfo = command.Split();


                for (int i = 0; i < engineInfo.Length - 1; i += 2)
                {
                    int horsePower = int.Parse(engineInfo[i]);
                    double cubicCapacity = double.Parse(engineInfo[i + 1]);

                    engines.Add(new Engine(horsePower, cubicCapacity));
                }
            }

            List<Car> cars = new List<Car>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("Show special"))
                {
                    break;
                }

                string[] carInfo = command.Split();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);

                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);

                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
            }

            Car[] specialCars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower >= 330).ToArray();

            foreach (var car in specialCars)
            {
                StringBuilder builder = new StringBuilder();
                double sum = 0;

                for (int i = 0; i < 4; i++)
                {
                    sum += car.Tires[i].Pressure;
                }

                if (sum >= 9 && sum <= 10)
                {
                    car.Drive(20);

                    builder.AppendLine($"Make: {car.Make}");
                    builder.AppendLine($"Model: {car.Model}");
                    builder.AppendLine($"Year: {car.Year.ToString()}");
                    builder.AppendLine($"HorsePowers: {car.Engine.HorsePower.ToString()}");
                    builder.AppendLine($"FuelQuantity: {car.FuelQuantity.ToString()}");

                    Console.Write(builder);
                }
            }
        }
    }
}