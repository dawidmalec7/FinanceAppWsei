using System;
using NUnit.Framework;
using FinanceAppWsei.Models;
using Tests.config;

namespace Tests
{
    class MoneyBoxesContextTests : DatabaseVariables
    {
        [Test]
        public void ShouldCreateMoneyBoxWithCorrectValues()
        {
            SetupDB();
            Guid userId = new Guid();
            databaseContext.Users.Add(new User
            {
                Id = userId,
                FirstName = "test",
                LastName = "test",
                Login = "fvdf",
                Password = "fdvdfv",
                CreatedOn = new DateTime(),
            });
            databaseContext.SaveChanges();


            MoneyBox moneyBox = new MoneyBox
            {
                Id = new Guid(),
                Title = "Title",
                Target = 333333,
                Value = 100,
                UserId = userId,
                CreatedOn = DateTime.Now
            };

            databaseContext.MoneyBoxes.Add(moneyBox);
            var saveMoneyBox = databaseContext.SaveChanges();
            Assert.AreEqual(saveMoneyBox, 1);
        }
    }
}
