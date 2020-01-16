using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestRegisterPage
{
    public class Tests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("/Users/krystiansmolen/Downloads");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http:localhost:3000");
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }

        [Test]
        public void ItShouldCreateNewAccounts()
        {
            IWebElement loginForm = driver.FindElement(By.Id("Login"));
            loginForm.SendKeys("login");

            IWebElement passwordForm = driver.FindElement(By.Id("password"));
            passwordForm.SendKeys("password");

            IWebElement firstNameForm = driver.FindElement(By.Id("FirstName"));
            firstNameForm.SendKeys("firstname");

            IWebElement lastNameForm = driver.FindElement(By.Id("LastName"));
            lastNameForm.SendKeys("lastname");

            IWebElement submitButton = driver.FindElement(By.Id("sign-in"));
            submitButton.Click();

            Thread.Sleep(1000);
            IWebElement balance = driver.FindElement(By.TagName("p"));

            Assert.AreEqual("Rejestracja przebiegła pomyślnie! Zaloguj sie obok!", balance.Text);
        }

        [Test]
        public void ItShouldLogInWithCorrectCredentials()
        {
            IWebElement loginForm = driver.FindElement(By.Name("login"));
            loginForm.SendKeys("login");

            IWebElement passwordForm = driver.FindElement(By.Name("password"));
            passwordForm.SendKeys("password");

            IWebElement submitButton = driver.FindElement(By.TagName("button"));
            submitButton.Click();
            Thread.Sleep(1000);

            IWebElement balance = driver.FindElement(By.TagName("p"));
            string assertValue = balance.Text;

            Assert.AreEqual(assertValue, "Your balance 0");
        }
    }
}