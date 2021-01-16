using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                //"{model} {power} {displacement} {efficiency}

                string engineModel = input[0];
                int enginePower = int.Parse(input[1]);
                int engineDisplacement = -1;
                string engineEfficiency = "n/a";

                if (input.Length == 3)
                {
                    string current = input[2];

                    if (char.IsDigit(current[0]))
                    {
                        engineDisplacement = int.Parse(current);

                        engines.Add(new Engine(engineModel, enginePower, engineDisplacement));
                    }
                    else
                    {
                        engineEfficiency = current;

                        engines.Add(new Engine(engineModel, enginePower, engineEfficiency));
                    }
                }
                else if (input.Length == 4)
                {
                    engineDisplacement = int.Parse(input[2]);
                    engineEfficiency = input[3];

                    engines.Add(new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency));
                }
                else
                {
                    engines.Add(new Engine(engineModel, enginePower));
                }

            }

            int M = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < M; i++)
            {
                var data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                //"{model} {engine} {weight} {color}" 

                string carModel = data[0];
                string carEngine = data[1];

                int weight = -1;
                string color = "n/a";

                Engine currEngine = engines.FirstOrDefault(x => x.Model == carEngine);


                if (data.Length == 3)
                {
                    string current = data[2];

                    if (char.IsDigit(current[0]))
                    {
                        weight = int.Parse(current);

                        cars.Add(new Car(carModel, currEngine, weight));
                    }
                    else
                    {
                        color = current;
                        cars.Add(new Car(carModel, currEngine, color));
                    }
                }
                else if (data.Length == 4)
                {
                    weight = int.Parse(data[2]);
                    color = data[3];

                    cars.Add(new Car(carModel, currEngine, weight, color));
                }
                else
                {
                    cars.Add(new Car(carModel, currEngine));
                }
            }

            Car.PrintAllCars(cars);
        }
    }
}
