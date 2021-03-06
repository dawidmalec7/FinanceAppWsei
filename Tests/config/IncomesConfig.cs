﻿using NUnit.Framework;
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
    class IncomesConfig : IncomesVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            Guid userGuidID = new Guid();

            databaseContext.Incomes.Add(GoodIncome);
            databaseContext.Users.Add(NewUser);
            databaseContext.SaveChanges();

            var userClaimsTypes = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userGuidID.ToString()),
                }, "mock"));

            IncomesControl = new IncomesController(databaseContext);

            IncomesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
        }

        [TearDown]
        public void CleanUpContext()
        {
            DbSet<Income> Incomes = databaseContext.Incomes;
            DbSet<User> Users = databaseContext.Users;
            foreach (var Income in Incomes)
            {
                databaseContext.Incomes.Remove(Income);
            }
            foreach (var User in Users)
            {
                databaseContext.Users.Remove(User);
            }
            databaseContext.SaveChanges();
        }
    }
}
