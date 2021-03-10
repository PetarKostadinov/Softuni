using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputCar = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();

            double carFuelQuantity = double.Parse(inputCar[1]);
            double carLitersPerKm = double.Parse(inputCar[2]);

            Vehicle car = new Car(carFuelQuantity, carLitersPerKm);

            var inputTruck = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            double truckFuelQuantity = double.Parse(inputTruck[1]);
            double truckLitersPerKm = double.Parse(inputTruck[2]);

            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var commands = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .ToList();

                string command = commands[0];
                string vehicle = commands[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    if (vehicle == "Car")
                    {

                        car.Drive(distance);
                    }
                    else
                    {
                        truck.Drive(distance);
                    }

                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(commands[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {(truck.FuelQuantity):F2}");
        }
    }
}
