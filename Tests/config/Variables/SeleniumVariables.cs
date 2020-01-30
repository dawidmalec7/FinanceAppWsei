using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.config;


namespace Tests
{
    public class SeleniumVariables : DatabaseVariables
    {
        public string ChromedriverPath = "/Users/krystiansmolen/Downloads";
        public string Host = "http:localhost:3000";
        public ChromeDriver driver;

        public void ConfigChromedriver()
        {
            driver = new ChromeDriver(ChromedriverPath);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Host);
        }
    }
}
