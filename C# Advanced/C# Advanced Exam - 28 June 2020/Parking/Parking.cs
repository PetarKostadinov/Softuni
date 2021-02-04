using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
           this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Capacity > data.Count)
            {
                this.data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var existingCar = this.data
                .FirstOrDefault(x => x.Manufacturer == manufacturer 
                && x.Model == model);
            
            if (existingCar != null)
            {
                this.data.Remove(existingCar);
              
                return true;
            }

            return false;
        }
        public Car GetLatestCar()
        {
            Car latestCar = this.data
                .OrderByDescending(x => x.Year)
                .FirstOrDefault();

            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car givenCar = data.FirstOrDefault(x => x.Manufacturer == manufacturer 
            && x.Model == model);

            return givenCar;
        }

        public string GetStatistics()
        {
            StringBuilder cars = new StringBuilder();

                cars.AppendLine($"The cars are parked in {this.Type}:");

                foreach (var car in data)
                {
                   cars.AppendLine(car.ToString());
                }
            return cars.ToString();
        }


    }
}
