using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bank;

        [SetUp]
        public void Setup()
        {
            bank = new BankVault();
        }

        [Test]
        public void TestAddItemShouldThrowExceptionWhenCellDoesNotExist()
        {
            Item item = new Item("A1", "123");
           

           
           
            Assert.Throws<ArgumentException>(() => { this.bank.AddItem("Ah", item); });
        }

        [Test]
        public void TestAddItemShouldThrowExceptionWhenCellIsNotNull()
        {
            Item item = new Item("A3", "123");
            Item item1 = new Item("A2", "456");
           
            this.bank.AddItem("A1", item);
       
            Assert.Throws<ArgumentException>(() => { this.bank.AddItem("A1", item1); });
        }

        [Test]
        public void TestAddItemShouldThrowExceptionWhenCellExists()
        {  
            Item item1 = new Item("A1", "123");

            this.bank.AddItem("A2", item1);

            Assert.Throws<InvalidOperationException>(() => { this.bank.AddItem("A1", item1); });
        }

        [Test]
        public void TestRemoveShouldThrowExceptionWhenCellDoesNotExist()
        {
            Item item = new Item("A1", "123");

            Assert.Throws<ArgumentException>(() => { this.bank.RemoveItem("Pesho", item); });
        }

        [Test]
        public void TestRemoveShouldThrowExceptionWhenCItemDoesNotExist()
        {
            Item item = new Item("A1", "123");
            Item item1 = new Item("A2", "123");
   
            this.bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => { this.bank.RemoveItem("A1", item1); });
        }

        [Test]
        public void TestRemoveShouldWork()
        {
            Item item = new Item("A1", "123");
            this.bank.AddItem("A1", item);
            this.bank.RemoveItem("A1", item);

            Assert.IsNull(this.bank.VaultCells["A1"]);
        }
    }
}