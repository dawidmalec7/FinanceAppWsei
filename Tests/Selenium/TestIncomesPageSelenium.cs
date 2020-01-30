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
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.XPath("//a[@href='/Incomes/incomes']"))));

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("titleIncome"))));

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("100");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("btn-success"))));

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("balance"))));

            string balance = driver.FindElement(By.ClassName("balance")).Text;
            Assert.AreEqual(balance, "Your balance 100$");
        }

        [Test]
        public void ItShouldNotCreateNewIncomeWithWrongValue()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.XPath("//a[@href='/Incomes/incomes']"))));

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("titleIncome"))));

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("valueIncome"))));

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("wrong_value");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("btn-success"))));

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("valueError"))));

            string notice = driver.FindElement(By.ClassName("valueError")).Text;
            Assert.AreEqual("Value wrong_value is invalid, please enter a number!", notice);
        }
    }
}