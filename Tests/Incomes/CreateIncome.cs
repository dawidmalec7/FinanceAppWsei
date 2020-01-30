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
            var income = await IncomesControl.CreateIncome(GoodIncome);
            Assert.AreEqual("Income has been created!", income.SuccessMessage);
        }

        [Test]
        public async Task CreateIncome_IncomeAddedToDatabase_RetrunTrue()
        {
            var income = await IncomesControl.CreateIncome(GoodIncome);
            var incomeCount = databaseContext.Incomes.Count();
            Assert.AreEqual(1, incomeCount);

        }
    }
}
