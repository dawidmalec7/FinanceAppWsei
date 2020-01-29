using NUnit.Framework;
using System;
using FinanceAppWsei.Models;
using FinanceAppWsei.Controllers;
using Tests.config.Variables;

namespace Tests.config
{
    public class UserConfig : UserVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            databaseContext.Users.Add(new User
                {
                    Id = new Guid(),
                    FirstName = "Dawid",
                    LastName = "Malec",
                    Login = "test",
                    Password = "test",
                    CreatedOn = new DateTime(),
                });
            databaseContext.SaveChanges();
            UsersControl = new UsersController(databaseContext, databaseConfiguration.Object);
        }
    }
}
