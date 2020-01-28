using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using FinanceAppWsei.Context;
using System;
using FinanceAppWsei.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using FinanceAppWsei.Controllers;

namespace Tests.config
{
    public class UserConfig : UserVariables
    {

        [SetUp]
        public void Setup()
        {
            databaseOptions = new DbContextOptionsBuilder<FinanceAppContext>()
               .UseInMemoryDatabase(databaseName: databaseName)
               .Options;

            using (var context = new FinanceAppContext(databaseOptions))
            {
                context.Users.Add(new User
                {
                    Id = new Guid(),
                    FirstName = "Dawid",
                    LastName = "Malec",
                    Login = "test",
                    Password = "test",
                    CreatedOn = new DateTime(),
                });
                context.SaveChanges();
            }
            Mock<IConfigurationSection> mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "default")]).Returns("testConnectionString");

            databaseConfiguration = new Mock<IConfiguration>();
            databaseConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(mockConfSection.Object);

            databaseContext = new FinanceAppContext(databaseOptions);
            UsersControl = new UsersController(databaseContext, databaseConfiguration.Object);
        }

        [TearDown]
        public void CleanUp()
        {
            
        }
    }
}
