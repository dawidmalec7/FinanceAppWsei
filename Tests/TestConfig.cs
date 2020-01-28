using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Tests
{
    public class TestConfig
    {
        public ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("/Users/krystiansmolen/Downloads");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http:localhost:3000");
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
