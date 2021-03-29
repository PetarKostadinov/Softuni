using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            } 
                this.drinks.Add(drink);
           
            return $"Added { name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            if (type == "Bread")
            {
                bakedFood = new Bread(name, price);
            }
            if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
            }
  
                this.bakedFoods.Add(bakedFood);
              
                return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }

            if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
 
                tables.Add(table);  

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
         
           return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            var bill = table.GetBill();
            totalIncome += bill;

            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
