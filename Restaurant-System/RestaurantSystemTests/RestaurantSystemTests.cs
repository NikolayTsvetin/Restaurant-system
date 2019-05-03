using System;
using Restaurant_System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestaurantSystemTests
{
    [TestClass]
    public class RestaurantSystemTests
    {
        [TestMethod]
        public void ShouldCreateFood()
        {
            var controller = new RestaurantController();
            var expectedFood = new Salad("Ceasers", 15.2M);
            var expectedReturnMessage = $"Added {expectedFood.GetName()} ({expectedFood.GetType().Name}) with price {expectedFood.GetPrice():f2} to the pool";
            var receivedMessageAfterCreatingFood = controller.AddFood("Salad", "Ceasers", 15.2M);

            Assert.AreEqual(expectedReturnMessage, receivedMessageAfterCreatingFood);
        }

        [TestMethod]
        public void ShouldCreateDrink()
        {
            var controller = new RestaurantController();
            var expectedDrink = new Water("Spring", 500, "Divna");
            var expectedReturnMessage = $"Added {expectedDrink.GetName()} (Divna) to the drink pool";
            var receivedMessageAfterCreatingDrink = controller.AddDrink("Water", "Spring", 500, "Divna");

            Assert.AreEqual(expectedReturnMessage, receivedMessageAfterCreatingDrink);
        }

        [TestMethod]
        public void ShouldCreateTable()
        {
            var controller = new RestaurantController();
            var expectedTable = new InsideTable(7, 23);
            var expectedReturnMessage = $"Added table number {expectedTable.TableNumber} in the restaurant";
            var receivedMessageAfterCreatingTable = controller.AddTable("InsideTable", 7, 23);

            Assert.AreEqual(expectedReturnMessage, receivedMessageAfterCreatingTable);
        }

        [TestMethod]
        public void ShouldReserveTable()
        {
            var controller = new RestaurantController();
            var createdTable = controller.AddTable("InsideTable", 7, 23);
            string expectedMessage = $"Table 7 has been reserved for 23 people";
            var receivedMessageAfterReservingTable = controller.ReserveTable(23);

            Assert.AreEqual(expectedMessage, receivedMessageAfterReservingTable);
        }

        [TestMethod]
        public void ShouldOrderFood()
        {
            var controller = new RestaurantController();
            var expectedFood = new Salad("Ceasers", 15.2M);
            var createdFood = controller.AddFood("Salad", "Ceasers", 15.2M);
            var createdTable = controller.AddTable("InsideTable", 7, 23);

            string expectedMessage = $"Table 7 ordered {expectedFood.GetName()}";
            var receivedMessageAferOrder = controller.OrderFood(7, expectedFood.GetName());

            Assert.AreEqual(expectedMessage, receivedMessageAferOrder);
        }

        [TestMethod]
        public void ShouldReturnAccurateMessageAfterLeavingTable()
        {
            var controller = new RestaurantController();
            var createdTable = controller.AddTable("InsideTable", 7, 23);
            var expectedTable = new InsideTable(7, 23);

            controller.ReserveTable(23);

            var expectedSalad = new Salad("Ceasers", 15.2M);
            var salad = controller.AddFood("Salad", "Ceasers", 15.2M);
            var expectedSoup = new Soup("Chicken", 5.8M);
            var soup = controller.AddFood("Soup", "Chicken", 5.8M);
            var expectedMain = new MainCourse("Burger", 8.7M);
            var main = controller.AddFood("MainCourse", "Burger", 8.7M);

            controller.OrderFood(7, expectedSalad.GetName());
            controller.OrderFood(7, expectedSoup.GetName());
            controller.OrderFood(7, expectedMain.GetName());

            decimal calculatedBill = expectedSalad.GetPrice() + expectedSoup.GetPrice() + expectedMain.GetPrice() + (23 * expectedTable.PricePerPerson);
            string expectedMessage = $"Table: 7\nBill: {calculatedBill:f2}";
            var receivedMessageAfterLeavingTable = controller.LeaveTable(7);

            Assert.AreEqual(expectedMessage, receivedMessageAfterLeavingTable);
        }

        [TestMethod]
        public void ShouldGetInfoForFreeTables()
        {
            var controller = new RestaurantController();
            var insideTable = new InsideTable(6, 13);
            var outsideTable = new OutsideTable(2, 4);
            var expectedMessage = insideTable.GetFreeTableInfo() + "\n" + outsideTable.GetFreeTableInfo() + "\n";
            var createdInsideTable = controller.AddTable("InsideTable", 6, 13);
            var createdOutsideTable = controller.AddTable("OutsideTable", 2, 4);
            var receivedMessage = controller.GetFreeTablesInfo();

            Assert.AreEqual(expectedMessage, receivedMessage);
        }

        [TestMethod]
        public void ShoudGetInfoForOccupiedTables()
        {
            var controller = new RestaurantController();
            var createdInsideTable = controller.AddTable("InsideTable", 6, 13);
            var createdOutsideTable = controller.AddTable("OutsideTable", 2, 4);
            var insideTable = new InsideTable(6, 13);
            var outsideTable = new OutsideTable(2, 4);

            controller.ReserveTable(13);
            controller.ReserveTable(4);
            insideTable.NumberOfPeople = 13;
            outsideTable.NumberOfPeople = 4;

            var expectedMessage = insideTable.GetOccupiedTableInfo() + "\n" + outsideTable.GetOccupiedTableInfo() + "\n";
            var receivedMessage = controller.GetOccupiedTablesInfo();

            Assert.AreEqual(expectedMessage, receivedMessage);
        }

        [TestMethod]
        public void ShouldReturnCorrectSummary()
        {
            var controller = new RestaurantController();
            var createdTable = controller.AddTable("InsideTable", 7, 23);
            var expectedTable = new InsideTable(7, 23);

            controller.ReserveTable(23);

            var expectedSalad = new Salad("Ceasers", 15.2M);
            var salad = controller.AddFood("Salad", "Ceasers", 15.2M);
            var expectedSoup = new Soup("Chicken", 5.8M);
            var soup = controller.AddFood("Soup", "Chicken", 5.8M);
            var expectedMain = new MainCourse("Burger", 8.7M);
            var main = controller.AddFood("MainCourse", "Burger", 8.7M);

            controller.OrderFood(7, expectedSalad.GetName());
            controller.OrderFood(7, expectedSoup.GetName());
            controller.OrderFood(7, expectedMain.GetName());

            decimal calculatedBill = expectedSalad.GetPrice() + expectedSoup.GetPrice() + expectedMain.GetPrice() + (23 * expectedTable.PricePerPerson);
            string expectedMessage = $"Total income: {calculatedBill:f2}lv";

            controller.LeaveTable(7);
            string receivedMessage = controller.GetSummary();

            Assert.AreEqual(expectedMessage, receivedMessage);
        }
    }
}
