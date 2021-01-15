using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine();
                var currCar = input.Split();

                string model = currCar[0];
                double fuelAmount = double.Parse(currCar[1]);
                double fuelConsumptionFor1km = double.Parse(currCar[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
            }
            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "End")
                {
                    break;
                }
                var currCommand = commands.Split();

                string carModel = currCommand[1];
                int amountOfKm = int.Parse(currCommand[2]);

                foreach (var car in cars.Where(x => x.Model == carModel))
                {
                    car.Drive(amountOfKm);
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

           
        }
    }
}
