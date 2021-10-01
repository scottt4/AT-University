using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AT_University
{
    [TestClass]
    public class Lecture9
    {
        private IWebDriver _driver;
        private readonly string _url = "https://pythonspot.com/selenium/";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void FindElementByDifferentMethods()
        {
            _driver.Navigate().GoToUrl(_url);
            var link = _driver.FindElement(By.LinkText("Selenium install"));
            link.Click();
            var Id = _driver.FindElement(By.Id("contact-form-name"));
            Id.Click();
            Id.SendKeys("Samuel");
            var Name = _driver.FindElement(By.Name("email"));
            Name.Click();
            Name.SendKeys("test@at.edu");

        }


        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}
