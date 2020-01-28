using NUnit.Framework;

namespace Tests
{
    public class TestConfig : Variables
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
