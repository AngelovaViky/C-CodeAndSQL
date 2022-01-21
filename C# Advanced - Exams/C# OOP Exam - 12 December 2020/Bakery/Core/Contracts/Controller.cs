using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> bakedFoods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal totalSumResturant;

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
            else if(type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
           
            this.bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in this.tables)
            {
                if (table is ITable && !(table as ITable).IsReserved)
                {
                    sb.AppendLine((table as ITable).GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            //var totalSum = this.tables.Select(s =>s.GetBill()).Sum();
            return $"Total income: {totalSumResturant:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal totalSum = table.GetBill();
            totalSumResturant += table.GetBill();
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
              .AppendLine($"Bill: {totalSum:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null || drink.Brand != drinkBrand)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t is ITable && !t.IsReserved);
            if (table == null || table.Capacity < numberOfPeople)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
