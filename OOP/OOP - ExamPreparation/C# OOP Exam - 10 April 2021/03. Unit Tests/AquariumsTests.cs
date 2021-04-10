namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
        private Fish fish2;

        [SetUp]

        public void Opjsh()
        {
            aquarium = new Aquarium("pep", 1);
            fish = new Fish("nik");
            fish2 = new Fish("brrr");


        }

        [Test]
        public void TestFishName()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 9));
        }
        [Test]
        public void TestCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("vyvygi", -17));
        }


        [Test]
        public void TestAddMethodThrowEx()
        {
            this.aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(fish));
        
        }

        [Test]
        public void Testaddmethodwork()
        {
            this.aquarium.Add(fish2);

            Assert.AreEqual(1, aquarium.Count);

        }


        [Test]
        public void TestRemoveThrowExc()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish(null));
        }

        [Test]
        public void TestRemoveWorks()
        {
            this.aquarium.Add(fish2);

            this.aquarium.RemoveFish(fish2.Name);

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void TestSellThrowExc()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish(null));
        }

        [Test]
        public void TestSellWorks()
        {
            this.aquarium.Add(fish2);

           var op =  this.aquarium.SellFish(fish2.Name);

            Assert.AreEqual(op, fish2);
        }

        [Test]
        public void TestSellWorksProperly()
        {
            this.aquarium.Add(fish2);

            var op = this.aquarium.SellFish(fish2.Name);

            Assert.That(op.Available == false);
        }
        [Test]
        public void TestReport()
        {
           var aquarium1 = new Aquarium("pep", 2);


            aquarium1.Add(fish2);
            aquarium1.Add(fish);

            var op = aquarium1.Report();

            Assert.AreEqual(op, "Fish available at pep: brrr, nik");
        }

    }
}
