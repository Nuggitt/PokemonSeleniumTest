using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSeleniumTest
{
    [TestClass]
    public class UnitTest
    {
        private static string DriverPath = @"c:\\WebDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _driver = new ChromeDriver(DriverPath);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod()
        {
            _driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            Assert.AreEqual("Poke Menu", _driver.Title);

            IWebElement element = _driver.FindElement(By.Id("getAllButton"));
            element.Click();

            IWebElement findByIdElement = _driver.FindElement(By.Id("inputSearchById"));
            findByIdElement.SendKeys("2");

            IWebElement findByIdButton = _driver.FindElement(By.Id("getByIdButton"));
            findByIdButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement pokeList = wait.Until(d => d.FindElement(By.Id("pokemonList")));
            Assert.IsTrue(pokeList.Text.Contains("Ivysaur"));

            ReadOnlyCollection<IWebElement> tableElements = _driver.FindElements(By.TagName("table"));
            Assert.IsTrue(tableElements.Count > 0);

            Assert.IsTrue(tableElements[0].Text.Contains("Bulbasaur"));

            //IWebElement findDeleteInput = _driver.FindElement(By.Id("inputDelete"));
            //findDeleteInput.SendKeys("99");

            //IWebElement deleteButton = _driver.FindElement(By.Id("deleteButton"));
            //deleteButton.Click();

            //Assert.IsNull(_driver.FindElement(By.Id("table")).Text.Contains("99"));






        }


    }
}
