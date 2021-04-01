using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bakery.Tables.Models
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> BakedFoods; 
        private ICollection<IDrink> Drinks;

        private int capacity;
        private int numberOfPeople;
        private bool isReserved;
        private decimal price;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.BakedFoods = new List<IBakedFood>();
            this.Drinks = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
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
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved 
        {
            get
            {
                return this.isReserved;
            }
            set
            {
                if (this.NumberOfPeople > 0)   //// CHECK FOR WRONG INPLEMENTATION  !!!
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
                this.isReserved = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                value = PricePerPerson * NumberOfPeople;

                this.price = value;
            }
        }

        public void Clear()
        {
            this.BakedFoods.Clear();
            this.Drinks.Clear();
            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            //decimal bill = this.NumberOfPeople * this.PricePerPerson;

            //return bill;

            ///// TO CHECK !!
            /////  IF IT IS THAT LOGYC
            decimal drinkBill = this.Drinks.Sum(x => x.Price);
            decimal foodBill = this.BakedFoods.Sum(x => x.Price);
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

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.Drinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.BakedFoods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            this.NumberOfPeople = numberOfPeople;

            // CHECK !!!

            //var table = this.tables.FirstOrDefault(x => x.Capacity >= numberOfPeople && x.IsReserved == false);
            //if (table != null)
            //{
            //    table.IsReserved = true;

            //    this.NumberOfPeople = numberOfPeople;

            //    Console.WriteLine(string.Format(OutputMessages.TableReserved), this.TableNumber, numberOfPeople);

            //}
            //else
            //{
            //    table.isReserved = false;
            //    Console.WriteLine(string.Format(OutputMessages.ReservationNotPossible), NumberOfPeople);
            //}
        }
    }
}
