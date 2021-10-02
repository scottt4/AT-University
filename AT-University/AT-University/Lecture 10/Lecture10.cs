using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AT_University
{
    [TestClass]
    public class Lecture10
    {
        private IWebDriver _driver;
        private readonly string _url = "https://google.com";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [TestMethod]
        public void FindElementByDifferentMethods()
        {
            _driver.Navigate().GoToUrl(_url);
            var searchBox = _driver.FindElement(By.TagName("input"));
            searchBox.Click();
            searchBox.SendKeys("Things to do in Tampa");
            searchBox.SendKeys(Keys.Return);
            var links = _driver.FindElements(By.TagName("cite"));
            System.Diagnostics.Debug.WriteLine(links.Count);
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(links[i]);
                    System.Diagnostics.Debug.WriteLine(links[i].);
                }
            }
            catch
            {
                Console.WriteLine("There are less than 10 links");
            }
        }

        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}