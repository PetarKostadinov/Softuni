namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void SetUp()
        {
            this.present = new Present("bear", 100);
            this.bag = new Bag();
        }

        [Test]
        public void TestPresentName()
        {
            Assert.That(this.present.Name == "bear");
        }

        [Test]
        public void TestPresentMagic()
        {
            Assert.That(this.present.Magic == 100);
        }

        [Test]
        public void TestBagCreateMethodThrowsEx()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));
        }

        [Test]
        public void TestBagCreateMethodThrowsEx1()
        {
            this.bag.Create(this.present);

            Assert.Throws<InvalidOperationException>(() => this.bag.Create(this.present));
        }

        [Test]
        public void TestBagCreateMethod()
        {
            this.bag.Create(this.present);

            var presents = new List<Present>() { this.present };

            CollectionAssert.AreEqual(presents, this.bag.GetPresents());
        }


        [Test]
        public void TestRemoveBagMethod()
        {
            this.bag.Create(this.present);

            Assert.IsTrue(this.bag.Remove(this.present));
        }

        [Test]
        public void TestGetPresentWithLeastMagicd()
        {
            this.bag.Create(this.present);
            this.bag.Create(new Present("cat", 150));

            Assert.IsTrue(this.bag.GetPresentWithLeastMagic() == this.present);
        }

        [Test]
        public void TestGetPresent()
        {
            this.bag.Create(this.present);

            Assert.IsTrue(this.bag.GetPresent("bear") == this.present);
        }
    }
}
