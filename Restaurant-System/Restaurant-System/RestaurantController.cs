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

        public string AddFood(string type, string name, decimal price)
        {
            try
            {
                if (type == FoodTypes.Dessert.ToString())
                {
                    Food dessert = new Dessert(name, price);

                    Menu.Add(dessert);
                }
                else if (type == FoodTypes.MainCourse.ToString())
                {
                    Food mainCourse = new MainCourse(name, price);

                    Menu.Add(mainCourse);
                }
                else if (type == FoodTypes.Salad.ToString())
                {
                    Food salad = new Salad(name, price);

                    Menu.Add(salad);
                }
                else if (type == FoodTypes.Soup.ToString())
                {
                    Food soup = new Soup(name, price);

                    Menu.Add(soup);
                }
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
                if (type == DrinkTypes.Alcohol.ToString())
                {
                    Drink alcohol = new Alcohol(name, servingSize, brand);

                    Drinks.Add(alcohol);
                }
                else if (type == DrinkTypes.FuzzyDrink.ToString())
                {
                    Drink fuzzyDrink = new FuzzyDrink(name, servingSize, brand);

                    Drinks.Add(fuzzyDrink);
                }
                else if (type == DrinkTypes.Juice.ToString())
                {
                    Drink juice = new Juice(name, servingSize, brand);

                    Drinks.Add(juice);
                }
                else if (type == DrinkTypes.Water.ToString())
                {
                    Drink water = new Water(name, servingSize, brand);

                    Drinks.Add(water);
                }
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
                if (type == TableTypes.InsideTable.ToString())
                {
                    Table insideTable = new InsideTable(tableNumber, capacity);

                    Tables.Add(insideTable);
                }
                else if (type == TableTypes.OutsideTable.ToString())
                {
                    Table outsideTable = new OutsideTable(tableNumber, capacity);

                    Tables.Add(outsideTable);
                }
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
            var foundTable = Tables.Where(table => table.TableNumber == tableNumber);

            if (foundTable.ToList().Count == 0)
            {
                return $"Could not find table with {tableNumber}";
            }

            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].TableNumber == tableNumber)
                {
                    for (int j = 0; j < Menu.Count; j++)
                    {
                        if (Menu[j].GetName() == foodName)
                        {
                            if (ordersPerTable.ContainsKey(tableNumber))
                            {
                                ordersPerTable[tableNumber] += Menu[j].GetPrice();
                            }
                            else
                            {
                                ordersPerTable.Add(tableNumber, Menu[j].GetPrice());
                            }

                            Tables[i].FoodOrders.Add(Menu[j]);

                            return $"Table {tableNumber} ordered {foodName}";
                        }
                    }
                }
            }

            return $"No {foodName} in the menu";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var foundTable = Tables.Where(table => table.TableNumber == tableNumber);

            if (foundTable.ToList().Count == 0)
            {
                return $"Could not find table with {tableNumber}";
            }

            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].TableNumber == tableNumber)
                {
                    for (int j = 0; j < Drinks.Count; j++)
                    {
                        if (Drinks[j].GetName() == drinkName)
                        {
                            if (ordersPerTable.ContainsKey(tableNumber))
                            {
                                ordersPerTable[tableNumber] += Drinks[j].GetPrice();
                            }
                            else
                            {
                                ordersPerTable.Add(tableNumber, Drinks[j].GetPrice());
                            }

                            Tables[i].DrinkOrders.Add(Drinks[j]);

                            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                        }
                    }
                }
            }

            return $"There is no {drinkName} {drinkBrand} available";
        }

        public string LeaveTable(int tableNumber)
        {
            var foundTable = Tables.Where(table => table.TableNumber == tableNumber);

            if (foundTable.ToList().Count == 0)
            {
                return $"Table with number: {tableNumber} is not found.";
            }

            decimal billForTable = ordersPerTable[tableNumber];

            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].TableNumber == tableNumber)
                {
                    billForTable += (Tables[i].PricePerPerson * Tables[i].NumberOfPeople);

                    paidBills += billForTable;
                    ordersPerTable.Remove(tableNumber);
                    Tables[i].Clear();
                }
            }

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
