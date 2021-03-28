using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private List<ICar> cars;
        private bool canParticipate;

        public Driver(string name)
        {
            this.Name = name;
            this.cars = new List<ICar>();
        }
        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 5 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate 
            => this.Car != null;
       

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }

            this.Car = car;
            
        }

        public void WinRace()
        {

            this.NumberOfWins++;
        }
    }
}
