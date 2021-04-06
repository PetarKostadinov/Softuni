using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer nullComputer;
        private Computer invalidModelComputer;
        private Computer invalidManufacturerComputer;
        private Computer invalidPriceCompute;
        private Computer validComputer;
        private Computer invalidPriceComputer;


        [SetUp]
        public void Setup()
        {
            this.validComputer = new Computer("ASUS", "1234", 1000);
            this.invalidPriceComputer = new Computer("ASUS", "1234", 0);
            this.invalidManufacturerComputer = new Computer(null, "1234", 1000);
            this.invalidModelComputer = new Computer("ASUS", null, 1000);
            this.nullComputer = null;
            computerManager = new ComputerManager();
        }
       

        [Test]
        public void TestAddComupterAndValidateNullValue()
        {


            Assert.Throws<ArgumentNullException>(() => { this.computerManager.AddComputer(this.nullComputer); });
        }
        [Test]
        public void TestAddComupter_ShouldThrowException_WhenModelAndNameAreEqwal()
        {
            this.computerManager.AddComputer(this.validComputer);

            Assert.Throws<ArgumentException>(() => { this.computerManager.AddComputer(this.validComputer); });
        }
        [Test]
        public void TestAddComupter_ShouldWorkProperly()
        {
            this.computerManager.AddComputer(this.validComputer);
            int expectedCount = 1;
            int actualCount = this.computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestRemoveComputer_ShouldWorkProperly()
        {
            this.computerManager.AddComputer(this.validComputer);
            this.computerManager.RemoveComputer("ASUS", "1234");

            int expectedCount = 0;
            int actualCount = this.computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestRemoveComputer_ShouldReturnComputer()
        {
            this.computerManager.AddComputer(this.validComputer);

            var expectedCount = this.validComputer;
            var actualCount = this.computerManager.RemoveComputer("ASUS", "1234");

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestRemoveComputer_ShouldThrowExceptionWhenComputerManufacturerIsNull()
        {
            this.computerManager.AddComputer(this.validComputer);

            Assert.Throws<ArgumentNullException>(() => { this.computerManager.RemoveComputer(null, "1234"); });
        }
        [Test]
        public void TestRemoveComputer_ShouldThrowExceptionWhenComputerModelIsNull()
        {
            this.computerManager.AddComputer(this.validComputer);

            Assert.Throws<ArgumentNullException>(() => { this.computerManager.RemoveComputer("ASUS", null); });
        }


        [Test]
        public void TestGetComputer_ShouldThrowExceptionWithWrongName()
        {
            this.computerManager.AddComputer(this.validComputer);


            Assert.Throws<ArgumentException>(() => { this.computerManager.GetComputer("greshno", "1234"); });
        }

        [Test]
        public void TestGetComputer_ShouldValidateManufacturer()
        {
            this.computerManager.AddComputer(this.validComputer);


            Assert.Throws<ArgumentNullException>(() => { this.computerManager.GetComputer(null, "1234"); });
        }
        [Test]
        public void TestGetComputer_ShouldValidateModel()
        {
            this.computerManager.AddComputer(this.validComputer);


            Assert.Throws<ArgumentNullException>(() => { this.computerManager.GetComputer("ASUS", null); });
        }
        [Test]
        public void TestGetComputer_ShouldThrowException_WhenComputerIsNull()
        {
            this.computerManager.AddComputer(this.validComputer);
            Assert.Throws<ArgumentException>(() => { this.computerManager.GetComputer("DELL", "4321"); });
        }
        [Test]
        public void TestGetComputer_ShouldThrowException_WhenComputerIsEmpty()
        {
          
            Assert.Throws<ArgumentException>(() => { this.computerManager.GetComputer("DELL", "4321"); });
        }
        [Test]
        public void TestGetComputer_ShouldReturnComputer()
        {
            this.computerManager.AddComputer(this.validComputer);

            var expectedCount = this.validComputer;
            var actualCount = this.computerManager.GetComputer("ASUS", "1234");

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestGetComputersByManufacturerr_ShouldValidateManufacturer_NullName()
        {
            this.computerManager.AddComputer(this.validComputer);

            Assert.Throws<ArgumentNullException>(() => { this.computerManager.GetComputersByManufacturer(null); });
        }

       
        [Test]
        public void TestGetComputersByManufacturer_ShouldReturnCorect()
        {
            this.computerManager.AddComputer(this.validComputer);

            ICollection<Computer> computers = this.computerManager.Computers
               .Where(c => c.Manufacturer == "ASUS")
               .ToList();

            Assert.AreEqual(computers, this.computerManager.GetComputersByManufacturer("ASUS"));
        }
        [Test]
        public void GetComputersByManufacturerShouldWork()
        {
            this.computerManager.AddComputer(this.validComputer);

            ICollection<Computer> comps = this.computerManager.GetComputersByManufacturer("ASUS");
            Assert.AreEqual(1, comps.Count);
        }
        [Test]
        public void GetComputersByManufacturer()
        {
            Computer computer1 = new Computer("ASUS", "1234", 1000);
            Computer computer2 = new Computer("ASUS", "5678", 1000);
            Computer computer3 = new Computer("HP", "91011", 1000);
            this.computerManager.AddComputer(computer1);
            this.computerManager.AddComputer(computer2);
            this.computerManager.AddComputer(computer3);

            ICollection<Computer> expectedComputers =
                this.computerManager.Computers.Where(x => x.Manufacturer == "ASUS").ToList();

            Assert.AreEqual(expectedComputers, computerManager.GetComputersByManufacturer("ASUS"));
        }

    }
}
