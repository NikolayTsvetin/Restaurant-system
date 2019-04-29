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

        protected List<IFood> FoodOrders = new List<IFood>();
        protected List<IDrink> DrinkOrders = new List<IDrink>();
        protected int TableNumber;
        protected int Capacity
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
        protected int NumberOfPeople
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
        protected decimal PricePerPerson;
        protected bool IsReserved;
        protected decimal Price
        {
            get
            {
                return this.NumberOfPeople * this.PricePerPerson;
            }
        }
        protected TableTypes TableType;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {TableNumber}\nType: {TableType}\nCapacity: {Capacity}\nPrice per Person: {PricePerPerson}";
        }

        public string GetOccupiedTableInfo()
        {
            string commonInfoForTable = $"Table: {TableNumber}\nType: {TableType}\nNumber of people: {NumberOfPeople}\n";

            if (FoodOrders.Count == 0 && DrinkOrders.Count == 0)
            {
                return commonInfoForTable + "Food orders: None\nDrink orders: None";
            }
            else if (FoodOrders.Count > 0 && DrinkOrders.Count == 0)
            {
                string foodInfo = "";

                foreach (var food in FoodOrders)
                {
                    foodInfo += food.ToString() + "\n";
                }

                return commonInfoForTable + foodInfo + "Drink orders: None";
            }
            else if (FoodOrders.Count == 0 && DrinkOrders.Count > 0)
            {
                string drinkInfo = "";

                foreach (var drink in DrinkOrders)
                {
                    drinkInfo += drink.ToString() + "\n";
                }

                return commonInfoForTable + "Food orders: None\n" + drinkInfo;
            }
            else
            {
                string foodInfo = "";
                string drinkInfo = "";

                foreach (var food in FoodOrders)
                {
                    foodInfo += food.ToString() + "\n";
                }

                foreach (var drink in DrinkOrders)
                {
                    drinkInfo += drink.ToString() + "\n";
                }

                return commonInfoForTable + foodInfo + drinkInfo;
            }
        }
    }
}
