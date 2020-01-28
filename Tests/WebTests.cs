using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using FinanceAppWsei.Context;
using System;
using FinanceAppWsei.Models;
using FinanceAppWsei.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    class WebTests
    {
        [Test]
        public async Task GetAllTestAsync()
        {
            var options = new DbContextOptionsBuilder<FinanceAppContext>()
                .UseInMemoryDatabase(databaseName: "FinanceApp")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new FinanceAppContext(options))
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

            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "default")]).Returns("mock value");

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(mockConfSection.Object);


            // Use a clean instance of the context to run the test
            using (var context = new FinanceAppContext(options))
            {
                UsersController controller = new UsersController(context, mockConfiguration.Object);
                User user = new User
                {
                    Login = "test",
                    Password = "test",
                };
                var x = await controller.LoginUser(user);
                Assert.AreEqual("You are logged in!", x.SuccessMessage);
            }
        }
    }
}
