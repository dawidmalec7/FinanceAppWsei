using NUnit.Framework;

namespace Tests
{
    public class TestConfig : SeleniumVariables
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
