using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {

        private string name;
        private int laps;
        private readonly ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
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
                    throw new ArgumentException( $"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }


        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
           
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(IDriver),"Driver cannot be null.");
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }

            if (this.drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(nameof(IDriver), $"Driver { driver.Name } is already added in { this.Name} race.");
            }

            this.drivers.Add(driver);
        }
    }
}
