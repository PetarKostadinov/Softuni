using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddDriverMethod_ShouldThrowException_WhenDriverIsNull()
        {


            Assert.Throws<InvalidOperationException>(() => 
            { 
                var raceEntry = new RaceEntry(); 
                raceEntry.AddDriver(null); 
            });
        }

        [Test]
        public void TestAddDriverMethod_ShouldThrowException_WhenDriverContainsName()
        {


            Assert.Throws<InvalidOperationException>(() =>
            {
            var raceEntry = new RaceEntry();
                var car = new UnitCar("sports", 100, 200);
                var driver = new UnitDriver("Pesho", car);
                raceEntry.AddDriver(driver);
                raceEntry.AddDriver(driver);
            });
        }


        [Test]
        public void TestCalculateAverageHorsePower_ShouldThrowException_WhenMinparticipantsAreLess()
        {

            var raceEntry = new RaceEntry();
            var car = new UnitCar("sports", 100, 200);
            var driver = new UnitDriver("Pesho", car);
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
               
            });
        }


        [Test]
        public void TestAddDriverShouldWork()
        {

            var raceEntry = new RaceEntry();
            var car = new UnitCar("sports", 100, 200);
            var driver = new UnitDriver("Pesho", car);
            var result = raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);
            Assert.AreEqual(result, $"Driver {driver.Name} added in race.");

        }


        [Test]
        public void TestCalculateAverageHorsePower_ShouldWork()
        {

            var raceEntry = new RaceEntry();
            var car = new UnitCar("sports", 100, 200);
            var car1 = new UnitCar("sports", 100, 200);
            var car2 = new UnitCar("sports", 100, 200);
            var driver = new UnitDriver("Pesho", car);
            var driver1 = new UnitDriver("Mesho", car1);
            var driver2 = new UnitDriver("Lesho", car2);
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            Assert.AreEqual(100, raceEntry.CalculateAverageHorsePower());
           
        }

    }
}