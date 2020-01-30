using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class TestsIncomesPage : DashboardTestsConfig
    {
        

        [Test]
        public void ItShouldSuccessfulCreateNewIncome()
        {
            Thread.Sleep(2000);

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();

            Thread.Sleep(2000);

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("100");

            Thread.Sleep(2000);

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            Thread.Sleep(2000);

            string balance = driver.FindElement(By.ClassName("balance")).Text;
            Assert.AreEqual(balance, "Your balance 100$");
        }

        [Test]
        public void ItShouldNotCreateNewIncomeWithWrongValue()
        {
            Thread.Sleep(2000);

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();

            Thread.Sleep(2000);

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("wrong_value");

            Thread.Sleep(2000);

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            Thread.Sleep(2000);

            string notice = driver.FindElement(By.ClassName("valueError")).Text;
            Assert.AreEqual("Value wrong_value is invalid, please enter a number!", notice);
        }
    }
}