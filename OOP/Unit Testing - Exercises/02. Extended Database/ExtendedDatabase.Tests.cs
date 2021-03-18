//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructorEmptyReturnZero()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            Assert.AreEqual(0, extendedDatabase.Count);
        }


        [Test]
        public void TestConstructorThrowsExeptionIfCountIsBigerThanSixteen()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                new ExtendedDatabase(people);
            });
        }

        [Test]
        public void TestAddPersonMethodShouldReturnCorectly()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(1, "Pesho"));

            Assert.AreEqual(1, extendedDatabase.Count);
        }

        [Test]
        public void TestAddPersonMethodShouldAddCorectlyProperties()
        {
            Person expected = new Person(1, "Pesho");

            ExtendedDatabase extendedDatabase = new ExtendedDatabase(expected);

            Person actual = extendedDatabase.FindById(1);

            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Pesho", actual.UserName);
        }

        [Test]
        public void TestAddPersonMethodShouldAddSHouldThrowExetionWhenAdd17()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i + 1, $"A{i}");
            }

            ExtendedDatabase extendedDatabase = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(new Person(1, "A"));
            });
        }

        [Test]
        public void TestShouldThrowExeptionWhenAddSameUssername()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            data.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(new Person(2, "A"));
            });
        }

        [Test]
        public void TestShouldThrowExeptionWhenAddSameId()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            data.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(new Person(1, "B"));
            });
        }

        [Test]
        public void TestShouldIncrementCountWhenAdd()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            data.Add(new Person(1, "A"));

            Assert.AreEqual(1, data.Count);
        }

        [Test]
        public void TestShouldReturnCorectly()
        {

            Person person = new Person(1, "A");


            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("A", person.UserName);
        }

        [Test]

        public void TestRemoveMethodIfCountIsZeroReturnExeption()
        {
            ExtendedDatabase data = new ExtendedDatabase();


            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Remove();
            });

        }

        [Test]

        public void TestRemoveMethodIfDecreaseCount()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Person person = new Person(1, "A");
            data.Add(person);
            data.Remove();

            Assert.AreEqual(0, data.Count);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void TestFindByUsernameMethodIfReturnExeptionIfUsserIsNullOrEmpty(string ussername)
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Person person = new Person(1, "A");


            Assert.Throws<ArgumentNullException>(() =>
            {
                data.FindByUsername(ussername);
            });

        }

        [Test]
        [TestCase("Pesho")]

        public void TestFindByUsernameMethodIfReturnExeptionIfUsserAndNameDoesNotMatch(string name)
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Person person = new Person(1, "A");

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.FindByUsername(name);
            });

        }


        [Test]

        public void TestFindByUsernameMethodIfReturnCorectly()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Person person = new Person(1, "A");

            data.Add(person);
            data.FindByUsername("A");

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("A", person.UserName);

        }

        [TestCase(-123456789)]

        public void TestFindByIdMethodThrowExeptionWhenIdIsBelowZero(long Id)
        {
            ExtendedDatabase data = new ExtendedDatabase(new Person(1, "A"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                data.FindById(Id);
            });
        }


        [Test]
        [TestCase(5)]

        public void TestFindByUsernameMethodIfReturnExeptionIfIDAndIdDoesNotMatch(long Id)
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Person person = new Person(1, "A");

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.FindById(Id);
            });

        }


        [TestCase(1)]

        public void TestFindByIdReturnCorectly(long Id)
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Person person = new Person(1, "A");

            data.Add(person);
           
                data.FindById(1);

            Assert.AreEqual(Id, person.Id);
            Assert.AreEqual("A", person.UserName);
        }
    }
}
