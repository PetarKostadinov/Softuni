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
            var car = this.carRepo.GetByName(carModel);
            var driver = this.driverRepo.GetByName(driverName);
            

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

          driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepo.GetByName(raceName);
            var driver = this.driverRepo.GetByName(driverName);


            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            var isInRepo = this.carRepo.GetByName(model);

            if (isInRepo != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            if (car != null)
            {
                this.carRepo.Add(car);
            }
            

            return $"{type + "Car"} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            Driver driver = new Driver(driverName);

            var isInRepo = this.driverRepo.GetByName(driverName);

            if (isInRepo != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            this.driverRepo.Add(driver);

            return $"Driver {driverName} is created.";


        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            var isInThere = this.raceRepo.GetByName(name);

            if (isInThere != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            this.raceRepo.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race { raceName } could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = race.Drivers
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(race.Laps))
                .ToList();

           

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {drivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {drivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {drivers[2].Name} is third in {raceName} race.");

            this.raceRepo.Remove(race);

            return sb.ToString().TrimEnd();

        }
    }
}
