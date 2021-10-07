using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AT_University
{
    [TestClass]
    public class Lecture11
    {
        private IWebDriver _driver;
        private string _url = "https://google.com";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [TestMethod]
        public void AssertionTestingExercise1()
        {
            _url = "https://demoqa.com/checkbox";
            _driver.Navigate().GoToUrl(_url);
            var expand = _driver.FindElement(By.CssSelector("button[title='Expand all']"));
            expand.Click();
            var documents = _driver.FindElement(By.XPath("//span[text()='Documents']"));
            documents.Click();
            var downloads = _driver.FindElement(By.XPath("//span[text()='Downloads']"));
            downloads.Click();
        }

        [TestMethod]
        public void AssertionTestingExercise2()
        {
            _url = "https://demoqa.com/radio-button";
            _driver.Navigate().GoToUrl(_url);
            var yesRadio = _driver.FindElement(By.CssSelector("label[for='yesRadio']"));
            yesRadio.Click();
            var impressiveRadio = _driver.FindElement(By.CssSelector("label[for='impressiveRadio']"));
            impressiveRadio.Click();
        }

        [TestMethod]
        public void AssertionTestingExercise3()
        {
            _url = "https://demoqa.com/webtables";
            _driver.Navigate().GoToUrl(_url);
            var Grid = _driver.FindElements(By.CssSelector("div[role='gridcell']"));
            Assert.IsTrue(Grid[3].Text.Contains("@"));
        }

        [TestMethod]
        public void AssertionTestingExercise4()
        {
            _url = "https://demoqa.com/select-menu";
            _driver.Navigate().GoToUrl(_url);

            var menu1 = _driver.FindElement(By.XPath("(//input[@id='react-select-2-input'])[1]"));
            menu1.SendKeys("Group 1, option 2");
            menu1.SendKeys(Keys.Return);

            var menu2 = _driver.FindElement(By.XPath("(//input[@id='react-select-3-input'])"));
            menu2.SendKeys("Mr.");
            menu2.SendKeys(Keys.Return);

            var menu3 = _driver.FindElement(By.Id("oldSelectMenu"));
            menu3.Click();
            menu3.SendKeys(Keys.ArrowDown);
            menu3.SendKeys(Keys.Return);

            var menu4 = _driver.FindElements(By.ClassName("css-2b097c-container"))[2];
            menu4.Click();
            var menu4Item = _driver.FindElement(By.Id("react-select-4-option-1"));
            menu4Item.Click();

            var menu5 = _driver.FindElement(By.CssSelector("option[value='saab']"));
            menu5.Click();
        }

        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}