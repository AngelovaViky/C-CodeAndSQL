using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.Capacity = capacity;
            this.TableNumber = tableNumber;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();

        }
        public int TableNumber { get; private set; }

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
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved => this.numOfPeople > 0;

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            var result = this.drinkOrders.Select(d => d.Price).Sum() + this.foodOrders.Select(d => d.Price).Sum();

            return result;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();

            this.NumberOfPeople = 0;
        }
        
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}")
              .AppendLine($"Type: {GetType().Name}")
              .AppendLine($"Capacity: {this.Capacity}")
              .AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return sb.ToString().TrimEnd();
        }

    }
}
