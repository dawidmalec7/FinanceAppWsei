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
        public UsersController UsersControl;
    }
}
