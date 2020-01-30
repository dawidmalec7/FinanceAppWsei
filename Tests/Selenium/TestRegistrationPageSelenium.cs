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

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.CssSelector(".register-form .col-md-8 p"))));
            string  notice = driver.FindElement(By.CssSelector(".register-form .col-md-8 p")).Text;

            Assert.AreEqual("Rejestracja przebiegła pomyślnie! Zaloguj sie obok!", notice);
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

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.TagName("button"))));
            string balance = driver.FindElement(By.TagName("button")).Text;

            Assert.AreEqual("Logout", balance);
        }

        [Test]
        public void ItShouldNotLogInWithWrongCredentials()
        {
            IWebElement loginForm = driver.FindElement(By.Name("login"));
            loginForm.SendKeys("wrong_login");

            IWebElement passwordForm = driver.FindElement(By.Name("password"));
            passwordForm.SendKeys("wrong_password");

            IWebElement submitButton = driver.FindElement(By.TagName("button"));

            submitButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("loginError"))));
            IWebElement notice = driver.FindElement(By.ClassName("loginError"));

            Assert.AreEqual("Invalid username or password!", notice.Text);
        }
    }
}