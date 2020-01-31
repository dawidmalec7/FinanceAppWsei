using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;

namespace Tests.Categories
{
    class CreateCategory : CategoriesConfig
    {
        [Test]
        public async Task AddCategory_CorrectData_ReturnSuccesMessage()
        {
            Category GoodCategory1 = new Category
             {
                 Title = "Category21",
             };
            var Category = await CategoriesControl.AddCategory(GoodCategory1);
            Assert.AreEqual("Category has been created!", Category.SuccessMessage);
        }

        [Test]
        public async Task AddCategory_CategoryAddedToDatabase_RetrunTrue()
        {

            Category GoodCategory1 = new Category
            {
                Title = "Category21",
            };
            var Category = await CategoriesControl.AddCategory(GoodCategory1);
            var CategoryCount = databaseContext.Categories.Count();
            //one is added by default
            Assert.AreEqual(2, CategoryCount);

        }
    }
}
