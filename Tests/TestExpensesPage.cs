using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class TestsExpensesPage : DashboardTestsConfig
    {


        [Test]
        public void ItShouldSuccessfulCreateNewExpenses()
        {
            Thread.Sleep(2000);

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Expenses/expenses']"));
            link.Click();

            Thread.Sleep(2000);

            IWebElement title = driver.FindElement(By.Id("titleExpense"));
            title.SendKeys("wydatek");

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement value = driver.FindElement(By.Id("valueExpense"));
            value.SendKeys("100");

            Thread.Sleep(2000);

            IWebElement submitButton = driver.FindElement(By.ClassName("btn-success"));
            submitButton.Click();

            Thread.Sleep(2000);

            string balance = driver.FindElement(By.ClassName("balance")).Text;
            Assert.AreEqual("Your balance -100$", balance);
        }
    }
}