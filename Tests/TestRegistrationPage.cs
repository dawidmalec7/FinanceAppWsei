using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Tests
{
    public class TestsRegistrationPage : SeleniumConfig
    {
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
            Thread.Sleep(2000);
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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

            Thread.Sleep(2000);
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string balance = driver.FindElement(By.TagName("button")).Text;

            Assert.AreEqual("Logout", balance);
        }
    }
}