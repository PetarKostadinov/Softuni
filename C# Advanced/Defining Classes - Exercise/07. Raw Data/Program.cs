using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split().ToArray();


                //The speed, power, weight and tire age are integers and tire pressure is a double.

                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoTipe = data[4];

                double tirePresure = double.Parse(data[5]);//tires 
                int tireAge = int.Parse(data[6]);

                double tire2Presure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);

                double tire3Presure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);

                double tire4Presure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);

                Engine engine = new Engine(engineSpeed, enginePower);

                Cargo cargo = new Cargo(cargoWeight, cargoTipe);

                Tire[] tires = new Tire[4]
                 {
                      new Tire(tirePresure, tireAge),
                      new Tire(tire2Presure, tire2Age),
                      new Tire(tire3Presure, tire3Age),
                      new Tire(tire4Presure, tire4Age)

                };

                cars.Add(new Car(model, engine, cargo, tires));

            }

            string fragileOrFlamable = Console.ReadLine();


            if (fragileOrFlamable.Equals("fragile"))
            {
                foreach (var car in cars.Where(x => x.Cargo.Type.Equals("fragile")))
                {
                    if (car.Tires.Any(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {

                foreach (var car in cars.Where(x => x.Cargo.Type.Equals("flamable")))
                {
                    if (car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }

        }
    }
}
