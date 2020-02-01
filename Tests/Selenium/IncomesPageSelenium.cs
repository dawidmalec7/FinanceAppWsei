using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Tests.Selenium
{
    public class IncomesPage : DashboardTestsConfig
    {
        

        [Test]
        public void ItShouldSuccessfulCreateNewIncome()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((By.XPath("//a[@href='/Incomes/incomes']"))));

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("100");

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras
                .WaitHelpers
                .ExpectedConditions
                .TextToBePresentInElementLocated(By.ClassName("balance"), "Your balance 100$"));


            string balance = driver.FindElement(By.ClassName("balance")).Text;
            Assert.AreEqual("Your balance 100$", balance);
        }

        [Test]
        public void ItShouldNotCreateNewIncomeWithWrongValue()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((By.XPath("//a[@href='/Incomes/incomes']"))));

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("wrong_value");

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras
                .WaitHelpers
                .ExpectedConditions
                .TextToBePresentInElementLocated(By.ClassName("valueError"), "Value wrong_value is invalid, please enter a number!"));

            string notice = driver.FindElement(By.ClassName("valueError")).Text;
            Assert.AreEqual("Value wrong_value is invalid, please enter a number!", notice);
        }
    }
}