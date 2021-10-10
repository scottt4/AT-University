using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace AT_University
{
    [TestClass]
    public class Lecture14
    {
        private IWebDriver _driver;
        private readonly string _url = "https://tailspintoys.azurewebsites.net/?slug=model";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]

        public void AddToCartMethod1()
        {
            _driver.Navigate().GoToUrl(_url);
            var airplane1 = _driver.FindElement(By.PartialLinkText("Research Rocket"));
            airplane1.Click();
            var submit = _driver.FindElement(By.CssSelector("input[type='Submit']"));
            submit.Click();
            var checkout = _driver.FindElement(By.CssSelector("input[title='Proceed to checkout']"));
            checkout.Click();
            _driver.FindElement(By.Id("FirstName")).SendKeys("Sam");
            _driver.FindElement(By.Id("LastName")).SendKeys("Smith");
            _driver.FindElement(By.Id("Email")).SendKeys("sammysmith@gmail.com");
            _driver.FindElement(By.Id("Street1")).SendKeys("100 Test Drive");
            _driver.FindElement(By.Id("City")).SendKeys("Tampa");
            _driver.FindElement(By.Id("Zip")).SendKeys("44455");
            var state = _driver.FindElement(By.Id("stateSelect"));
            state.Click();
            state.SendKeys(Keys.ArrowDown);
            state.SendKeys(Keys.Return);
            var submit2 = _driver.FindElement(By.CssSelector("input[type='Submit']"));
            submit2.Click();
            var submit3 = _driver.FindElement(By.CssSelector("input[type='Submit']"));
            submit3.Click();
            var receipt = _driver.FindElement(By.XPath("//td[text()='Trey Research Rocket']"));
            Assert.AreEqual(receipt.Text, "Trey Research Rocket");
        }

        [TestMethod]

        public void AddToCartMethod2()
        {
            _driver.Navigate().GoToUrl(_url);
            var airplane1 = _driver.FindElement(By.PartialLinkText("Coffee Flyer"));
            airplane1.Click();
            var submit = _driver.FindElement(By.CssSelector("input[type='Submit']"));
            submit.Click();
            var checkout = _driver.FindElement(By.CssSelector("input[title='Proceed to checkout']"));
            checkout.Click();
            _driver.FindElement(By.Id("FirstName")).SendKeys("Sam");
            _driver.FindElement(By.Id("LastName")).SendKeys("Smith");
            _driver.FindElement(By.Id("Email")).SendKeys("sammysmith@gmail.com");
            _driver.FindElement(By.Id("Street1")).SendKeys("100 Test Drive");
            _driver.FindElement(By.Id("City")).SendKeys("Tampa");
            _driver.FindElement(By.Id("Zip")).SendKeys("44455");
            var state = _driver.FindElement(By.Id("stateSelect"));
            state.Click();
            state.SendKeys(Keys.ArrowDown);
            state.SendKeys(Keys.Return);
            var submit2 = _driver.FindElement(By.CssSelector("input[type='Submit']"));
            submit2.Click();
            var submit3 = _driver.FindElement(By.CssSelector("input[type='Submit']"));
            submit3.Click();
            var receipt = _driver.FindElement(By.XPath("//td[text()='Fourth Coffee Flyer']"));
            Assert.AreEqual(receipt.Text, "Fourth Coffee Flyer");
        }

        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}