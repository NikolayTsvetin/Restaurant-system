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

        public string AddFood(string type, string name, decimal price)
        {
            throw new NotImplementedException();
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            throw new NotImplementedException();
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            throw new NotImplementedException();
        }

        public string ReserveTable(int numberOfPeople)
        {
            throw new NotImplementedException();
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            throw new NotImplementedException();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            throw new NotImplementedException();
        }

        public string LeaveTable(int tableNumber)
        {
            throw new NotImplementedException();
        }

        public string GetFreeTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }

    }
}
