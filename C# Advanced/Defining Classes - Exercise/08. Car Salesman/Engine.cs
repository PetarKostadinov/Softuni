using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficiency = "n/a";
        }

        public Engine(string model, int power,int displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
