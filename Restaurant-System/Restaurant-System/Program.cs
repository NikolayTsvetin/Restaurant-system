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
            RestaurantController controller = new RestaurantController();

            Console.WriteLine("------- FIRST TEST CASE -------");
            Console.WriteLine(controller.AddFood("Dessert", "Toffifee", 2.9m));
            Console.WriteLine(controller.AddDrink("Water", "Spring", 500, "Divna"));
            Console.WriteLine(controller.AddTable("InsideTable", 1, 10));
            Console.WriteLine(controller.AddTable("OutsideTable", 2, 20));
            Console.WriteLine(controller.ReserveTable(5));
            Console.WriteLine(controller.OrderFood(1, "Toffifee"));
            Console.WriteLine(controller.OrderDrink(1, "Spring", "Divna"));
            Console.WriteLine(controller.GetOccupiedTablesInfo());
            Console.WriteLine(controller.GetFreeTablesInfo());
            Console.WriteLine(controller.LeaveTable(1));

            //AddFood Dessert Toffifee 2.90
            //AddDrink Water Spring 500 Divna
            //AddTable Inside 1 10
            //AddTable Outside 2 20
            //ReserveTable 5
            //OrderFood 1 Toffifee
            //OrderDrink 1 Spring Divna
            //GetOccupiedTablesInfo
            //GetFreeTablesInfo
            //LeaveTable 1
            //END

            Console.WriteLine("------- END FIRST TEST CASE -------");
            Console.WriteLine("------- SECOND TEST CASE -------");

            RestaurantController secondController = new RestaurantController();

            Console.WriteLine(secondController.AddFood("Dessert", "Toffifee", 2.9m));
            Console.WriteLine(secondController.AddFood("Salad", "Shopska", 12.9m));
            Console.WriteLine(secondController.AddFood("Soup", "Bob", 12.9m));
            Console.WriteLine(secondController.AddFood("MainCourse", "Chushki", -90m));
            Console.WriteLine(secondController.AddDrink("Water", "Spring", -500, "Divna"));
            Console.WriteLine(secondController.AddDrink("Alcohol", "Rakia", 200, "YambolskaPerla"));
            Console.WriteLine(secondController.AddDrink("FuzzyDrink", "PeachSchnapps", 200, "Monin"));
            Console.WriteLine(secondController.AddTable("InsideTable", 1, 10));
            Console.WriteLine(secondController.AddTable("InsideTable", 2, 12));
            Console.WriteLine(secondController.AddTable("InsideTable", 3, 11));
            Console.WriteLine(secondController.AddTable("OutsideTable", 4, 20));
            Console.WriteLine(secondController.AddTable("OutsideTable", 5, -2));
            Console.WriteLine(secondController.AddTable("OutsideTable", 6, 10));
            Console.WriteLine(secondController.ReserveTable(5));
            Console.WriteLine(secondController.ReserveTable(1));
            Console.WriteLine(secondController.ReserveTable(2));
            Console.WriteLine(secondController.OrderFood(1, "Toffifee"));
            Console.WriteLine(secondController.OrderFood(1, "Shopska"));
            Console.WriteLine(secondController.OrderFood(2, "Bob"));
            Console.WriteLine(secondController.OrderFood(3, "Bob"));
            Console.WriteLine(secondController.OrderFood(4, "Bob"));
            Console.WriteLine(secondController.OrderDrink(1, "Spring", "Divna"));
            Console.WriteLine(secondController.OrderDrink(2, "Spring", "Divna"));
            Console.WriteLine(secondController.OrderDrink(2, "Spring", "YambolskaPerla"));
            Console.WriteLine(secondController.OrderDrink(3, "Spring", "Monin"));
            Console.WriteLine(secondController.GetOccupiedTablesInfo());
            Console.WriteLine(secondController.GetFreeTablesInfo());
            Console.WriteLine(secondController.LeaveTable(1));
            Console.WriteLine(secondController.LeaveTable(2));
            Console.WriteLine(secondController.GetSummary());



            //AddFood Dessert Toffifee 2.90
            //AddFood Salad Shopska 12.90
            //AddFood Soup Bob 12.90
            //AddFood MainCourse Chushki - 90
            //AddDrink Water Spring - 500 Divna
            //AddDrink Alcohol Rakia 200 YambolskaPerla
            //AddDrink FuzzyDrink PeachSchnapps 200 Monin
            //AddTable Inside 1 10
            //AddTable Inside 2 12
            //AddTable Inside 3 11
            //AddTable Outside 4 20
            //AddTable Outside 5 - 2
            //AddTable Outside 6 10
            //ReserveTable 5
            //ReserveTable 1
            //ReserveTable 2
            //OrderFood 1 Toffifee
            //OrderFood 1 Shopska
            //OrderFood 2 Bob
            //OrderFood 3 Bob
            //OrderFood 4 Bob
            //OrderDrink 1 Spring Divna
            //OrderDrink 2 Spring Divna
            //OrderDrink 2 Spring YambolskaPerla
            //OrderDrink 3 Spring Monin
            //GetOccupiedTablesInfo
            //GetFreeTablesInfo
            //LeaveTable 1
            //LeaveTable 2
            //END



            Console.WriteLine("------- END SECOND TEST CASE -------");

        }
    }
}
