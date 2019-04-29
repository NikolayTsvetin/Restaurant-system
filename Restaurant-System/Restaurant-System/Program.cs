using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Food dessert = new Dessert("creme", 20.2M);
            Food salad = new Salad("ceaser", 30.8M);
            Food main = new MainCourse("steak", 54.7M);

            Console.WriteLine(dessert.ToString());
            Console.WriteLine(salad.ToString());
            Console.WriteLine(main.ToString());

            Drink fuzzyDrink = new FuzzyDrink("Pepsi", 500, "Cola");
            Drink juice = new Juice("Strawberry", 250, "Cappy");
            Drink water = new Water("Mineral water", 750, "Devin");
            Drink alcohol = new Alcohol("Whiskey", 50, "Jack Daniels");

            Console.WriteLine(fuzzyDrink.ToString());
            Console.WriteLine(juice.ToString());
            Console.WriteLine(water.ToString());
            Console.WriteLine(alcohol.ToString());

            Table insideTable = new InsideTable(7, 25);
            Table outsideTable = new OutsideTable(6, 12);

            Console.WriteLine(outsideTable.GetFreeTableInfo());
            Console.WriteLine(outsideTable.GetOccupiedTableInfo());
        }
    }
}
