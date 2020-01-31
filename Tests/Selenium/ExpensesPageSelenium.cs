using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Tests.Selenium
{
    public class ExpensesPage : DashboardTestsConfig
    {


        [Test]
        public void ItShouldSuccessfulCreateNewExpenses()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.XPath("//a[@href='/Expenses/expenses']"))));

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Expenses/expenses']"));
            link.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("titleExpense"))));

            IWebElement title = driver.FindElement(By.Id("titleExpense"));
            title.SendKeys("wydatek");


            IWebElement value = driver.FindElement(By.Id("valueExpense"));
            value.SendKeys("100");


            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("balance"))));

            string balance = driver.FindElement(By.ClassName("balance")).Text;
            Assert.AreEqual("Your balance -100$", balance);
        }
        [Test]
        public void ItShouldNotCreateNewExpensesWithWrongValue()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.XPath("//a[@href='/Expenses/expenses']"))));

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Expenses/expenses']"));
            link.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("titleExpense"))));

            IWebElement title = driver.FindElement(By.Id("titleExpense"));
            title.SendKeys("wydatek");


            IWebElement value = driver.FindElement(By.Id("valueExpense"));
            value.SendKeys("wrong_value");


            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("valueError"))));

            string notice = driver.FindElement(By.ClassName("valueError")).Text;
            Assert.AreEqual("Value wrong_value is invalid, please enter a number!", notice);
        }
    }
}