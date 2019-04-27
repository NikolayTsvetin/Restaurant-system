using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public abstract class Table
    {
        private int _capacity;
        private int _numberOfPeople;

        private List<Food> FoodOrders = new List<Food>();
        private List<Drink> DrinkOrders = new List<Drink>();
        private int TableNumber;
        private int Capacity
        {
            get
            {
                return this._capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to greater than 0");
                }

                this._capacity = value;
            }
        }
        private int NumberOfPeople
        {
            get
            {
                return this._numberOfPeople;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this._numberOfPeople = value;
            }
        }
        private decimal PricePerPerson;
        private bool IsReserved;
        private decimal Price
        {
            get
            {
                return this.NumberOfPeople * this.PricePerPerson;
            }
        }

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        private void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        private void OrderFood(IFood food)
        {
            throw new NotImplementedException();
        }

        private void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }

        private decimal GetBill()
        {
            throw new NotImplementedException();
        }

        private void Clear()
        {
            throw new NotImplementedException();
        }

        public string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTableInfo()
        {
            throw new NotImplementedException();
        }
    }
}
