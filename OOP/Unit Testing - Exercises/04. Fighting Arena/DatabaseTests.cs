
using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] intialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(intialData);
        }

        [Test]
        public void TestifConstructorWorksPropely()
        {
            int[] data = new int[] { 1, 2, 3 };

            this.database = new Database.Database(data);

            int expectedCount = data.Length;

            int actualCount = database.Count;

            Assert.AreEqual(actualCount, expectedCount);
        }
        [Test]
        public void IfConstructorThrowingExWhenCollectionIsBigger()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database.Database(data);
            });
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.database.Add(3);

            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddTroingExWhenDatabaseFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => { this.database.Add(17); });
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            int expectedCount = 1;
            this.database.Remove();

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void IfThrowExWhenDatabaseEmpty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() => { this.database.Remove(); });
        }

        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]

        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database.Database(expectedData);

            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

    }
}