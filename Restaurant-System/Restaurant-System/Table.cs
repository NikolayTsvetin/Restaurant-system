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

        public List<IFood> FoodOrders = new List<IFood>();
        public List<IDrink> DrinkOrders = new List<IDrink>();
        public int TableNumber;
        public int Capacity
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
        public int NumberOfPeople
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
        public decimal PricePerPerson;
        public bool IsReserved;
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
                string foodInfo = "Food orders: " + FoodOrders.Count + "\n";

                foreach (var food in FoodOrders)
                {
                    foodInfo += food.ToString() + "\n";
                }

                return commonInfoForTable + foodInfo + "Drink orders: None";
            }
            else if (FoodOrders.Count == 0 && DrinkOrders.Count > 0)
            {
                string drinkInfo = "Drink orders: " + DrinkOrders.Count + "\n";

                foreach (var drink in DrinkOrders)
                {
                    drinkInfo += drink.ToString() + "\n";
                }

                return commonInfoForTable + "Food orders: None\n" + drinkInfo;
            }
            else
            {
                string foodInfo = "Food orders: " + FoodOrders.Count + "\n";
                string drinkInfo = "Drink orders: " + DrinkOrders.Count + "\n";

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

        public void Clear()
        {
            FoodOrders = new List<IFood>();
            DrinkOrders = new List<IDrink>();
            IsReserved = false;
            NumberOfPeople = 0;
        }
    }
}
