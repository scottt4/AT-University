using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AT_University
{
    [TestClass]
    public class example
    {
        private IWebDriver _driver;
        private readonly string _url = "http://www.google.com";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void AbleToSearchGoogle()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}
