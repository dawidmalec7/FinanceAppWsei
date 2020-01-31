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
    class CategoriesConfig : CategoriesVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            Guid userGuidID = new Guid();

            databaseContext.Categories.Add(TestCategory);
            databaseContext.Users.Add(NewUser);
            databaseContext.SaveChanges();

            var userClaimsTypes = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userGuidID.ToString()),
                }, "mock"));

            CategoriesControl = new CategoriesController(databaseContext);

            CategoriesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
        }

        [TearDown]
        public void CleanUpContext()
        {
            DbSet<Category> Categories = databaseContext.Categories;
            DbSet<User> Users = databaseContext.Users;
            foreach (var Category in Categories)
            {
                databaseContext.Categories.Remove(Category);
            }
            foreach (var User in Users)
            {
                databaseContext.Users.Remove(User);
            }
            databaseContext.SaveChanges();
        }
    }
}
