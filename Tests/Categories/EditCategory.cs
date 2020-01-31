using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests.Categories
{
    class EditCategory : CategoriesConfig
    {
        [Test]
        public async Task EditCategory_CorrectData_ReturnSuccessMessage()
        {
            List<Category> Categories = await databaseContext.Categories.ToListAsync();

             Category CategoryToUpdate = new Category
             {
                 Title = "Category21",
             };

            var CategoryUpdated = await CategoriesControl.EditCategory(CategoryToUpdate, Categories[0].Id);
            Assert.AreEqual("Category has been changed", CategoryUpdated.SuccessMessage);
        }

        [Test]
        public async Task EditCategory_WrongIDCategory_ReturnProperlyMessage()
        {
            var testGuidID = new Guid();
            Category CategoryToUpdate = new Category
            {
                Title = "Category21",
            };
            var CategoryUpdated = await CategoriesControl.EditCategory(CategoryToUpdate, testGuidID);
            Assert.AreEqual("Category with provided ID hasn't been found", CategoryUpdated.ClientError);
        }
    }
}
