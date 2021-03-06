﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class InsideTable : Table
    {
        private const decimal CostPerPerson = 2.5M;

        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, CostPerPerson)
        {
            TableType = TableTypes.InsideTable;
        }

        private void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }

        private void OrderFood(IFood food)
        {
            FoodOrders.Add(food);
        }

        private void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        private decimal GetBill()
        {
            decimal totalSum = 0;

            foreach (var foodOrder in FoodOrders)
            {
                totalSum += foodOrder.GetPrice();
            }

            foreach (var drinkOrder in DrinkOrders)
            {
                totalSum += drinkOrder.GetPrice();
            }

            return totalSum;
        }
    }
}
