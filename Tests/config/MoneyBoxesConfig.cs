using NUnit.Framework;
using System;
using FinanceAppWsei.Models;
using FinanceAppWsei.Controllers;
using Tests.config.Variables;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FinanceAppWsei.Context;

namespace Tests.config
{
    class MoneyBoxesConfig : MoneyBoxesVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            Guid userGuidID = new Guid();
            MoneyBox GoodMoneyBoxes = new MoneyBox
            {
                Title = "MoneyBoxes2132",
                Value = 123
            };
            databaseContext.MoneyBoxes.Add(GoodMoneyBoxes);
            databaseContext.Users.Add(NewUser);
            databaseContext.SaveChanges();

            var userClaimsTypes = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userGuidID.ToString()),
                }, "mock"));

            MoneyBoxesControl = new MoneyBoxesController(databaseContext);

            MoneyBoxesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
        }

        [TearDown]
        public void CleanUpContext()
        {
            DbSet<MoneyBox> MoneyBoxes = databaseContext.MoneyBoxes;
            DbSet<User> Users = databaseContext.Users;
            foreach (var MoneyBox in MoneyBoxes)
            {
                databaseContext.MoneyBoxes.Remove(MoneyBox);
            }
            foreach (var User in Users)
            {
                databaseContext.Users.Remove(User);
            }
            databaseContext.SaveChanges();
        }
    }
}
