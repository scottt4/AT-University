using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AT_University
{
    [TestClass]
    public class Lecture13
    {
        private IWebDriver _driver;
        private readonly string _url = "https://www.google.com/";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();

        }

        [TestMethod]
        [TestCategory("Search")]

        public void SearchFileTest()
        {
            _driver.Navigate().GoToUrl(_url);
            var search = _driver.FindElement(By.CssSelector("input[title='Search']"));
            string text = System.IO.File.ReadAllText("../../../Lecture 13/SearchString.txt");

            search.SendKeys(text);
            search.SendKeys(Keys.Return);

        }

        [TestMethod]
        [TestCategory("Media"), TestCategory("Regression")]

        public void SearchSocialMediaLinks()
        {
            _driver.Navigate().GoToUrl("https://agilethought.com/");
            var linkedIn = _driver.FindElement(By.CssSelector("a[href='http://www.linkedin.com/company/agilethought']"));
            var facebook = _driver.FindElement(By.CssSelector("a[href='https://www.facebook.com/AgileThought']"));
            var twitter = _driver.FindElement(By.CssSelector("a[href='https://twitter.com/AgileThought']"));
            var instagram = _driver.FindElement(By.CssSelector("a[href='https://www.instagram.com/agilethought/']"));

            Assert.IsTrue(linkedIn.Displayed && facebook.Displayed && twitter.Displayed && instagram.Displayed);

        }

        [TestMethod]
        [TestCategory("Search"), TestCategory("Regression")]

        public void SearchAmazonTest()
        {
            _driver.Navigate().GoToUrl("https://www.amazon.com");
            var search = _driver.FindElement(By.Id("twotabsearchtextbox"));
            string text = System.IO.File.ReadAllText("../../../Lecture 13/AmazonSearchString.txt");

            search.SendKeys(text);
            search.SendKeys(Keys.Return);

        }

        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}