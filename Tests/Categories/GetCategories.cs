using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;

namespace Tests.Categories
{
    class GetCategories : CategoriesConfig
    {
        [Test]
        public async Task GetCategories_CorrectData_ReturnResponseObject()
        {
            var getCategory = await CategoriesControl.GetCategories();
            Assert.IsInstanceOf(typeof(Response), getCategory);
        }

        [Test]
        public async Task GetCategory_CorrectData_ReturnListOfCategory()
        {
           var getCategory = await CategoriesControl.GetCategories();
           Assert.IsInstanceOf(typeof(List<Category>), getCategory.Data);
        }

    }
}
