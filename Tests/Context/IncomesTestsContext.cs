using System;
using NUnit.Framework;
using FinanceAppWsei.Context;
using FinanceAppWsei.Models;
using System.Security.Claims;
using Tests.config;

namespace Tests
{
    class IncomesContextTests : DatabaseVariables
    {
        [Test]
        public void ShouldCreateIncomeWithCorrectValues()
        {
            SetupDB();
            Guid userId = new Guid();
            databaseContext.Users.Add(new User
            {
                Id = userId,
                FirstName = "user",
                LastName = "useeeer",
                Login = "test",
                Password = "test",
                CreatedOn = new DateTime(),
            });
            databaseContext.SaveChanges();


            Income income = new Income {
                Id = new Guid(),
                Title = "Title",
                Value = 100,
                UserId = userId,
                CreatedOn = DateTime.Now
             };

            databaseContext.Incomes.Add(income);
            var saveIncome = databaseContext.SaveChanges();
            Assert.AreEqual(saveIncome, 1);
        }
    }
}
