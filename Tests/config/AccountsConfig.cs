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
    class AccountsConfig : AccountsVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            Guid userGuidID = new Guid();

            databaseContext.Users.Add(NewUser);
            databaseContext.SaveChanges();

            var userClaimsTypes = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userGuidID.ToString()),
                }, "mock"));

            AccountsControl = new AccountsController(databaseContext);
            IncomesControl = new IncomesController(databaseContext);
            ExpensesControl = new ExpensesController(databaseContext);

            AccountsControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
            IncomesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
            ExpensesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
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
