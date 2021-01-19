using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
           this.cars = new List<Car>();
        }
        public int Count => this.cars.Count;

     

        public string  AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!"; 
            }

            if (cars.Count == capacity)
            {
                return"Parking is full!";
            }
            
            
                cars.Add(car);

               return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            
            
        }
        public string RemoveCar(string registrationNumber)
        {
            if (cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                cars.Remove(cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));

                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }

        }
        public Car GetCar(string registrationNumber)
        {
            var currCar = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            return currCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                var car = cars.FirstOrDefault(x => x.RegistrationNumber == regNum);

                cars.Remove(car);
            }
        }





    }
}
