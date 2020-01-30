using Microsoft.EntityFrameworkCore;
using FinanceAppWsei.Context;
using Moq;
using Microsoft.Extensions.Configuration;
using FinanceAppWsei.Controllers;


namespace Tests.config
{
    public class DatabaseVariables
    {

        public string databaseName = "FinanceApp";
        public DbContextOptions<FinanceAppContext> databaseOptions;
        public Mock<IConfiguration> databaseConfiguration;
        public FinanceAppContext databaseContext;

        public void SetDBOptions()
        {
            databaseOptions = new DbContextOptionsBuilder<FinanceAppContext>()
             .UseInMemoryDatabase(databaseName: databaseName)
             .Options;
        }
        public void SetDBContext()
        {
            databaseContext = new FinanceAppContext(databaseOptions);
        }

        public void SetDBConfiguration()
        {
            Mock<IConfigurationSection> mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "default")]).Returns("testConnectionString");

            databaseConfiguration = new Mock<IConfiguration>();
            databaseConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(mockConfSection.Object);
        }

        public void SetupDB()
        {
            SetDBOptions();
            SetDBContext();
            SetDBConfiguration();
        }
   
    }
}
