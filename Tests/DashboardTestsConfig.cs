using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class DashboardTestsConfig
    {
        public ChromeDriver driver;

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
            driver.Close();
        }
    }
}
