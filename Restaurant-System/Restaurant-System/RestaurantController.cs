using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class RestaurantController
    {
        private List<IFood> Menu = new List<IFood>();
        private List<IDrink> Drinks = new List<IDrink>();
        private List<Table> Tables = new List<Table>();
        private Dictionary<int, decimal> ordersPerTable = new Dictionary<int, decimal>();
        private decimal paidBills = 0;

        private Food CreateFood(string type, string name, decimal price)
        {
            Food createdFood = null;

            switch (type)
            {
                case "Dessert":
                    createdFood = new Dessert(name, price);
                    break;
                case "MainCourse":
                    createdFood = new MainCourse(name, price);
                    break;
                case "Salad":
                    createdFood = new Salad(name, price);
                    break;
                case "Soup":
                    createdFood = new Soup(name, price);
                    break;
                default:
                    throw new ArgumentException();
            }

            return createdFood;
        }

        private Drink CreateDrink(string type, string name, int servingSize, string brand)
        {
            Drink createdDrink = null;

            switch (type)
            {
                case "Alcohol":
                    createdDrink = new Alcohol(name, servingSize, brand);
                    break;
                case "FuzzyDrink":
                    createdDrink = new FuzzyDrink(name, servingSize, brand);
                    break;
                case "Juice":
                    createdDrink = new Juice(name, servingSize, brand);
                    break;
                case "Water":
                    createdDrink = new Water(name, servingSize, brand);
                    break;
                default:
                    throw new ArgumentException();
            }

            return createdDrink;
        }

        private Table CreateTable(string type, int tableNumber, int capacity)
        {
            Table createdTable = null;

            switch (type)
            {
                case "InsideTable":
                    createdTable = new InsideTable(tableNumber, capacity);
                    break;
                case "OutsideTable":
                    createdTable = new OutsideTable(tableNumber, capacity);
                    break;
                default:
                    throw new ArgumentException();
            }

            return createdTable;
        }

        private Table FindTableByTableNumber(int tableNumber)
        {
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].TableNumber == tableNumber)
                {
                    return Tables[i];
                }
            }

            return null;
        }

        private IFood FindFoodByName(string foodName)
        {
            for (int i = 0; i < Menu.Count; i++)
            {
                if (Menu[i].GetName() == foodName)
                {
                    return Menu[i];
                }
            }

            return null;
        }

        private IDrink FindDrinkByName(string drinkName)
        {
            for (int i = 0; i < Drinks.Count; i++)
            {
                if (Drinks[i].GetName() == drinkName)
                {
                    return Drinks[i];
                }
            }

            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            try
            {
                Food createdFood = CreateFood(type, name, price);

                Menu.Add(createdFood);
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            try
            {
                Drink createdDrink = CreateDrink(type, name, servingSize, brand);

                Drinks.Add(createdDrink);
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            try
            {
                Table createdTable = CreateTable(type, tableNumber, capacity);

                Tables.Add(createdTable);
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].Capacity >= numberOfPeople && !Tables[i].IsReserved)
                {
                    Tables[i].IsReserved = true;
                    Tables[i].NumberOfPeople = numberOfPeople;

                    return $"Table {Tables[i].TableNumber} has been reserved for {numberOfPeople} people";
                }
            }

            return $"No available table for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var foundTable = FindTableByTableNumber(tableNumber);

            if (foundTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var foundFood = FindFoodByName(foodName);

            if (foundFood == null)
            {
                return $"No {foodName} in the menu";
            }

            if (ordersPerTable.ContainsKey(tableNumber))
            {
                ordersPerTable[tableNumber] += foundFood.GetPrice();
            }
            else
            {
                ordersPerTable.Add(tableNumber, foundFood.GetPrice());
            }

            foundTable.FoodOrders.Add(foundFood);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var foundTable = FindTableByTableNumber(tableNumber);

            if (foundTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var foundDrink = FindDrinkByName(drinkName);

            if (foundDrink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            if (ordersPerTable.ContainsKey(tableNumber))
            {
                ordersPerTable[tableNumber] += foundDrink.GetPrice();
            }
            else
            {
                ordersPerTable.Add(tableNumber, foundDrink.GetPrice());
            }

            foundTable.DrinkOrders.Add(foundDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var foundTable = FindTableByTableNumber(tableNumber);

            if (foundTable == null)
            {
                return $"Table with number: {tableNumber} is not found.";
            }

            decimal billForTable = ordersPerTable[tableNumber];

            billForTable += (foundTable.PricePerPerson * foundTable.NumberOfPeople);
            paidBills += billForTable;
            ordersPerTable.Remove(tableNumber);
            foundTable.Clear();

            return $"Table: {tableNumber}\nBill: {billForTable:f2}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder freeTablesInfo = new StringBuilder();

            for (int i = 0; i < Tables.Count; i++)
            {
                if (!Tables[i].IsReserved)
                {
                    freeTablesInfo.Append(Tables[i].GetFreeTableInfo());
                    freeTablesInfo.Append("\n");
                }
            }

            return freeTablesInfo.ToString();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder occupiedTablesInfo = new StringBuilder();

            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].IsReserved)
                {
                    occupiedTablesInfo.Append(Tables[i].GetOccupiedTableInfo());
                    occupiedTablesInfo.Append("\n");
                }
            }

            return occupiedTablesInfo.ToString();
        }

        public string GetSummary()
        {
            return $"Total income: {paidBills:f2}lv";
        }
    }
}
