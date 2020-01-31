using System;
using NUnit.Framework;
using FinanceAppWsei.Models;
using Tests.config;

namespace Tests.Context
{
    class CategoiesContextTests : DatabaseVariables
    {
        [Test]
        public void ShouldCreateCategoryWithCorrectValues()
        {
            SetupDB();
            Guid userId = new Guid();
            databaseContext.Users.Add(new User
            {
                Id = userId,
                FirstName = "name",
                LastName = "nameeee",
                Login = "test232",
                Password = "42342kjjjHKj",
                CreatedOn = new DateTime(),
            });
            databaseContext.SaveChanges();


            Category category = new Category
            {
                Id = new Guid(),
                Title = "Title",
                CreatedBy = userId,
                CreatedOn = DateTime.Now
            };

            databaseContext.Categories.Add(category);
            var saveCategory = databaseContext.SaveChanges();
            Assert.AreEqual(saveCategory, 1);
        }
    }
}
