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
            double carTrunkCapacity = double.Parse(inputCar[3]);

            Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTrunkCapacity);

            var inputTruck = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            double truckFuelQuantity = double.Parse(inputTruck[1]);
            double truckLitersPerKm = double.Parse(inputTruck[2]);
            double truckTrunkCapacity = double.Parse(inputTruck[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTrunkCapacity);

            var inputBus = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();


            double busFuelQuantity = double.Parse(inputBus[1]);
            double busLitersPerKm = double.Parse(inputBus[2]);
            double busTrunkCapacity = double.Parse(inputBus[3]);

            Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTrunkCapacity);


            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var commands = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .ToList();

                string command = commands[0];
                string vehicle = commands[1];

                    double distance = double.Parse(commands[2]);
                if (command == "Drive")
                {

                    if (vehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    else
                    {
                        ((Bus)bus).TurnOnAirconditioner();

                        bus.Drive(distance);
                    }

                }
                else if (command == "DriveEmpty")
                {
                    ((Bus)bus).TurnOffAirconditioner();

                    bus.Drive(distance);
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(commands[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(fuel);
                    }
                    else
                    {
                        bus.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {(truck.FuelQuantity):F2}");
            Console.WriteLine($"Bus: {(bus.FuelQuantity):F2}");
        }
    }
}
