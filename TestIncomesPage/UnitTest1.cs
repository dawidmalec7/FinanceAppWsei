using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TestIncomesPage
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
            IWebElement loginForm = driver.FindElement(By.Name("login"));
            loginForm.SendKeys("login");

            IWebElement passwordForm = driver.FindElement(By.Name("password"));
            passwordForm.SendKeys("password");

            IWebElement submitButton = driver.FindElement(By.TagName("button"));

            submitButton.Click();
        }

        [TearDown]
        public void CloseDriver()
        {
            //driver.Close();
        }

        [Test]
        public void Test1()
        {
            Thread.Sleep(2000);
            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("100");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(6000);
            IWebElement submitButton = driver.FindElement(By.TagName("button"));
            submitButton.Click();
            Thread.Sleep(6000);
        }
    }
}