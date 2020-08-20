using System;
using System.Collections.Generic;
using System.IO;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _repo;
        private Menu _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _content = new Menu(1, "Pizza", "One slice of Pizza", "pepperoni, cheese, sauce", 3.50m);

            _repo.AddContentToMenu(_content);
        }


        [TestMethod]
        public void TestMethod1()
        {
            var cafeTests = new Menu(1, "Cake", "Tasty Cake", "flour, icing, egg", 5);
            //need to test all the methods
            Assert.AreEqual(1, cafeTests.MealNum);

            var repo = new MenuRepository();
            var cafeOne = new Menu(1, "Pizza", "One slice of Pizza", "pepperoni, cheese, sauce", 3);
            var cafeTwo = new Menu(2, "Coffee", "Cup of coffee", "coffee beans, water, creamer, sweetner", 8);
            repo.AddContentToMenu(cafeOne);
            repo.AddContentToMenu(cafeTwo);
            repo.DeleteContentFromMenu(cafeOne);
            repo.RemoveContentFromList("pizza");
            repo.GetMenu();
            Assert.IsFalse(repo.RemoveContentFromList("pizza"));
        }

        [TestMethod]
        public void GetData_ShouldReturnCollection()
        {
            MenuRepository repo = new MenuRepository();
            MenuUI testing = new MenuUI();
            Menu menu = new Menu();

            repo.AddContentToMenu(menu);

            List<Menu> directory = repo.GetMenu();

            bool hasItem = directory.Contains(menu);
            Assert.IsTrue(hasItem);
        }
        [TestMethod]
        public void DeleteData()
        {
            bool deleteResult = _repo.RemoveContentFromList(_content.MealName);
            Assert.IsTrue(deleteResult);

            
        }

        [TestMethod]
        [DataRow("Pizza")]
        public void GetByName(string title)
        {
            List<Menu> testing = _repo.GetMenu();
            
            var yes = _repo.GetByName(title);
            bool hasIt = testing.Contains(yes);
            Assert.IsTrue(hasIt);
        }
    }
}
