using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

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
            Cookie cookie = new Cookie("AccessToken", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImIyN2U3Mzg1LTZmMzktNDIxZC04NTU5LTA4ZDc5YWFmYmNmNCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE1ODE3OTUxNzMsImlzcyI6ImxvY2FsaG9zdDo0NDMxMCIsImF1ZCI6ImxvY2FsaG9zdDo0NDMxMCJ9.687HlMQ4BhwNJn8nBi7cVX8HxGugecQwHw8ac_3LzSs");
            driver.Manage().Cookies.AddCookie(cookie);
            driver.Navigate().GoToUrl("http:localhost:3000");
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }

        [Test]
        public void Test1()
        {
            IWebElement link = driver.FindElement(By.XPath("//a[@href='/Incomes/incomes']"));
            link.Click();
            Thread.Sleep(1000);

            IWebElement title = driver.FindElement(By.Id("titleIncome"));
            title.SendKeys("wydatek");

            Thread.Sleep(1000);

            IWebElement value = driver.FindElement(By.Id("valueIncome"));
            value.SendKeys("100.0");

            Thread.Sleep(1000);

            IWebElement submitButton = driver.FindElement(By.TagName("button"));
            submitButton.Click();
        }
    }
}