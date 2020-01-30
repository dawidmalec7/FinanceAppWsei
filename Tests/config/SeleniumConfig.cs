using NUnit.Framework;

namespace Tests
{
    public class SeleniumConfig : SeleniumVariables
    {
        [SetUp]
        public void Setup()
        {
            ConfigChromedriver();
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
