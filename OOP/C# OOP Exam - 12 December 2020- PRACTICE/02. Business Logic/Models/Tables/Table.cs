using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;

        private int tableNumber;
        private int capacity;
        private int numOfPeople;
        private decimal pricePP;

        private Table()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        protected Table(int tableNum, int capacity, decimal pricePP) : this()
        {
            this.TableNumber = tableNum;
            this.Capacity = capacity;
            this.PricePerPerson = pricePP;
        }

        public int TableNumber
        {
            get { return this.tableNumber; }
            private set { this.tableNumber = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return this.pricePP; }
            private set { this.pricePP = value; }
        }

        public bool IsReserved { get; set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.Capacity = 0;
        }

        public decimal GetBill()
        {
            decimal drinkBill = this.drinkOrders.ToList().Sum(x => x.Price);
            decimal foodBill = this.foodOrders.ToList().Sum(x => x.Price);
            decimal totalPricePP = this.PricePerPerson * this.NumberOfPeople;
            return drinkBill + foodBill + totalPricePP;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            string info = sb.ToString().TrimEnd();
            return info;
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }
        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.numOfPeople = numberOfPeople;
        }
    }
}