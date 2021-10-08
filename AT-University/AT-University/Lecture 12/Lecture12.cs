using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AT_University
{
    [TestClass]
    public class Lecture12
    {
        private IWebDriver _driver;
        private readonly string _url = "https://www.c-sharpcorner.com/register";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void JavaScriptTesting()
        {
            _driver.Navigate().GoToUrl(_url);
            IWebElement emailElement = _driver.FindElement(By.Id("ctl00_ContentMain_TextBoxEmail"));
            IWebElement firstNameElement = _driver.FindElement(By.Id("ctl00_ContentMain_TextBoxFirstName"));
            IWebElement lastNameElement = _driver.FindElement(By.Id("ctl00_ContentMain_TextBoxLastName"));
            IWebElement passwordElement = _driver.FindElement(By.Id("ctl00_ContentMain_TextBoxPassword"));
            IWebElement passwordConfirmationElement = _driver.FindElement(By.Id("ctl00_ContentMain_TextBoxPasswordConfirm"));
            IWebElement zipElement = _driver.FindElement(By.Id("TextBoxZip"));
            IWebElement cityElement = _driver.FindElement(By.Id("TextBoxCity"));
            IWebElement securityAnswerElement = _driver.FindElement(By.Id("ctl00_ContentMain_TextBoxAnswer"));

            IWebElement countryElement = _driver.FindElement(By.Id("ctl00_ContentMain_DropdownListCountry"));
            IWebElement securityElement = _driver.FindElement(By.Id("ctl00_ContentMain_DropdownListSecurityQuesion"));

            IWebElement sendMeUpdates = _driver.FindElement(By.Id("ctl00_ContentMain_CheckBoxNewsletter"));
            IWebElement iAccept = _driver.FindElement(By.Id("cbxIsGDPRAccepted"));

            IWebElement registerButton = _driver.FindElement(By.Id("ctl00_ContentMain_ButtonSave"));

            string email = "arguments[0].value = 'scottTest@gmail.com';";
            string first = "arguments[0].value = 'Scott';";
            string last = "arguments[0].value = 'Test';";
            string pass = "arguments[0].value = 'alphabet123';";
            string passConf = "arguments[0].value = 'alphabet123';";
            string zip = "arguments[0].value = '55334-2221';";
            string city = "arguments[0].value = 'Orlando';";
            string securityAnswer = "arguments[0].value = 'Some Answer';";

            string country = "arguments[0].value = 'Canada';";
            string security = "arguments[0].value = '1';";

            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;

            jse.ExecuteScript(email, emailElement);
            jse.ExecuteScript(first, firstNameElement);
            jse.ExecuteScript(last, lastNameElement);
            jse.ExecuteScript(pass, passwordElement);
            jse.ExecuteScript(passConf, passwordConfirmationElement);
            jse.ExecuteScript(zip, zipElement);
            jse.ExecuteScript(city, cityElement);
            jse.ExecuteScript(securityAnswer, securityAnswerElement);

            jse.ExecuteScript(country, countryElement);
            jse.ExecuteScript(security, securityElement);

            jse.ExecuteScript("arguments[0].click();", sendMeUpdates);
            jse.ExecuteScript("arguments[0].click();", iAccept);

            jse.ExecuteScript("arguments[0].click();", registerButton);

        }

        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}