using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    public class DashboardTestsConfig : SeleniumVariables
    {
        [SetUp]
        public void Setup()
        {
            ConfigChromedriver();
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
            driver.Close();
        }
    }
}
