//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("WV", "Golf", 10, 60)]
        [TestCase("BMW", "M3", 8, 65)]
        public void TestConstructor(string make,
                                    string model,
                                    double fuelConsumption,
                                    double fuelCapacity)
        {
            Car car = new Car(make: make,
                              model: model,
                              fuelConsumption: fuelConsumption,
                              fuelCapacity: fuelCapacity);

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestIfThroingExeptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "M3", 8, 65);
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestIfThroingExeptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("WV", model, 8, 65);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestIfThroingExeptionIfFuelConsumptionIsZeroOrBelow(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "M3", fuelConsumption, 65);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestIfThroingExeptionIfFuelCapacityIsZeroOrBelow(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "M3", 8, fuelCapacity);
            });
        }


        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestIfRefuelMethodThroingExeptionIfGivenFuelIsZeroOrBelow(double givenFuel)
        {
            Car car = new Car("BMW", "M3", 8, 65);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(givenFuel);
            });
        }

        [Test]
        [TestCase(50, 100, 50)]
        [TestCase(50, 40, 40)]
        public void TestIfRefuelMethodWorksProperly(double capacity,
                                                    double givenFuel,
                                                    double expectedAmount)
        {
            Car car = new Car("BMW", "M3", 8, capacity);

            car.Refuel(givenFuel);

            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);

        }

        [Test]
        [TestCase(10, 50, 505)]
        public void TestIfDriveMethodWorksProperly(double fuelConsumption, double fuelAmount, double distance)
        {
            Car car = new Car("BMW", "M3", fuelConsumption, 65);

            car.Refuel(fuelAmount);

            Assert.Throws<InvalidOperationException>(() => 
            {
                car.Drive(distance);
            });
        }

        [Test]
        public void TestIfDriveMethodShouldReduseFuelAsPerDistance()
        {
            Car car = new Car("BMW", "M3", 10, 100);

            car.Refuel(100);
            car.Drive(50);

            double expectedAmount = 95;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }
    }
}