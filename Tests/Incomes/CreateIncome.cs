using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;

namespace Tests.Incomes
{
    class CreateIncome : IncomesConfig
    {
        [Test]
        public async Task CreateIncome_CorrectData_ReturnSuccesMessage()
        {
             Income GoodIncome1 = new Income
             {
                 Title = "Income21",
                 Value = 12
             };
            var income = await IncomesControl.CreateIncome(GoodIncome1);
            Assert.AreEqual("Income has been created!", income.SuccessMessage);
        }

        [Test]
        public async Task CreateIncome_IncomeAddedToDatabase_RetrunTrue()
        {

            Income GoodIncome1 = new Income
            {
                Title = "Income21",
                Value = 12
            };
            var income = await IncomesControl.CreateIncome(GoodIncome1);
            var incomeCount = databaseContext.Incomes.Count();
            //one is added by default
            Assert.AreEqual(2, incomeCount);

        }
    }
}
