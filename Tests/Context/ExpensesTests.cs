using System;
using NUnit.Framework;
using FinanceAppWsei.Models;
using Tests.config;

namespace Tests
{
    class Expenses : DatabaseVariables
    {
        [Test]
        public void ShouldCreateExpenseWithCorrectValues()
        {
            SetupDB();
            Guid userId = new Guid();
            databaseContext.Users.Add(new User
            {
                Id = userId,
                FirstName = "fdfdf",
                LastName = "fdfdf",
                Login = "34234",
                Password = "654322",
                CreatedOn = new DateTime(),
            });
            databaseContext.SaveChanges();


            Expense expense = new Expense
            {
                Id = new Guid(),
                Title = "Title",
                Value = 100,
                UserId = userId,
                CreatedOn = DateTime.Now
            };

            databaseContext.Expenses.Add(expense);
            var saveExpense = databaseContext.SaveChanges();
            Assert.AreEqual(saveExpense, 1);
        }
    }
}
