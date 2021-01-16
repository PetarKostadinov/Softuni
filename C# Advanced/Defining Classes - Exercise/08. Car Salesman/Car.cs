using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = "n/a";
        }

        public Car(string model, Engine engine, string color)
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = color;
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = "n/a";
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public static void PrintAllCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                string carWeight = car.Weight.ToString();

                if (car.Weight == -1)
                {
                    carWeight = "n/a";
                }

                string carDisplacement = car.Engine.Displacement.ToString();

                if (car.Engine.Displacement == -1)
                {
                    carDisplacement = "n/a";
                }

                Console.WriteLine($"{car.Model}:\n {car.Engine.Model}:\n  Power: {car.Engine.Power}\n  Displacement: {carDisplacement}\n  Efficiency: {car.Engine.Efficiency}\n Weight: {carWeight}\n Color: {car.Color}");
            }
        }
    }
}

            

        
    

