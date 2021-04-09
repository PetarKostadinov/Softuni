using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar unitCar;
        private RaceEntry raceEntry;
        private UnitDriver unitDriver;
        private UnitDriver unitDriver1;

        [SetUp]
        public void Setup()
        {
            this.unitCar = new UnitCar("OP", 100, 100);
            this.unitDriver = new UnitDriver("Pesho", unitCar);
            this.unitDriver1 = new UnitDriver("Niki", unitCar);
            this.raceEntry = new RaceEntry();

        }

        [Test]
        public void TestAddDriverShouldThrowExceptionWhenNUll()
        {
            Assert.Throws<InvalidOperationException>(() => { this.raceEntry.AddDriver(null); });
        }


        [Test]
        public void TestAddDriverShouldThrowExceptionWhenContainsSameName()
        {
            this.raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() =>  this.raceEntry.AddDriver(unitDriver));
        }

        [Test]
        public void TestAddDriverShouldAdd()
        {
            this.raceEntry.AddDriver(unitDriver);

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void TestAddDriverShouldReturnCorect()
        {
            var actual = this.raceEntry.AddDriver(unitDriver);

            Assert.AreEqual(actual, string.Format("Driver {0} added in race.", unitDriver.Name));
        }

        [Test]
        public void TestCalculateAverageHorsePowerShouldThrowException()
        {
            this.raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());

        }

        [Test]
        public void TestCalculateAverageHorsePowerShouldReturnCorect()
        {
             this.raceEntry.AddDriver(unitDriver);
             this.raceEntry.AddDriver(unitDriver1);

            Assert.AreEqual(100, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}