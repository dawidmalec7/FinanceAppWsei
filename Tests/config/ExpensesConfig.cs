using NUnit.Framework;
using System;
using FinanceAppWsei.Models;
using FinanceAppWsei.Controllers;
using Tests.config.Variables;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Tests.config
{
    class ExpensesConfig : ExpensesVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            Guid userGuidID = new Guid();

            databaseContext.Expenses.Add(GoodExpense);
            databaseContext.Users.Add(NewUser);
            databaseContext.SaveChanges();

            var userClaimsTypes = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userGuidID.ToString()),
                }, "mock"));

            ExpensesControl = new ExpensesController(databaseContext);

            ExpensesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
        }

        [TearDown]
        public void CleanUpContext()
        {
            DbSet<Expense> Expenses = databaseContext.Expenses;
            DbSet<User> Users = databaseContext.Users;
            foreach (var Expense in Expenses)
            {
                databaseContext.Expenses.Remove(Expense);
            }
            foreach (var User in Users)
            {
                databaseContext.Users.Remove(User);
            }
            databaseContext.SaveChanges();
        }
    }
}
