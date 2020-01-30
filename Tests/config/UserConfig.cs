using NUnit.Framework;
using System;
using FinanceAppWsei.Models;
using FinanceAppWsei.Controllers;
using Tests.config.Variables;
using Microsoft.EntityFrameworkCore;

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

        [TearDown]
        public void CleanUpContext()
        {
            DbSet<User> Users = databaseContext.Users;
            foreach (var User in Users)
            {
                databaseContext.Users.Remove(User);
            }
            databaseContext.SaveChanges();
        }
    }
}
