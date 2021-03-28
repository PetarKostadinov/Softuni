using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepo;
        private readonly IRepository<ICar> carRepo;
        private readonly IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            this.driverRepo = new DriverRepository();
            this.carRepo = new CarRepository();
            this.raceRepo = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepo.GetByName(driverName);
            var car = this.carRepo.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            this.carRepo.Remove(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepo.GetByName(raceName);
            var driver = this.driverRepo.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);    

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepo.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepo.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driverExist = this.driverRepo.GetByName(driverName);

            if (driverExist != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var driver = new Driver(driverName);

            this.driverRepo.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.raceRepo.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);

            this.raceRepo.Add(race);  // ??? to check

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = race
                .Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .ToList();

            var first = drivers[0];
            var second = drivers[1];
            var third = drivers[2];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {first.Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {second.Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {third.Name} is third in {race.Name} race.");

            this.raceRepo.Remove(race);

            return sb.ToString().TrimEnd();

        }
    }
}
