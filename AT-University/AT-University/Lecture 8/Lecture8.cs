using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AT_University
{
    [TestClass]
    public class Lecture8
    {
        private IWebDriver _driver;
        private readonly string _url = "https://pythonspot.com/selenium/";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void TitleIsCorrect()
        {
            _driver.Navigate().GoToUrl(_url);
            var title = _driver.FindElement(By.ClassName("post-title")).Text;
            Assert.AreEqual(title, "Selenium - Web Automation with Python");

        }


        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}
