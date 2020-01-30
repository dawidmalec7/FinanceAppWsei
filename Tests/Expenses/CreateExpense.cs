using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;

namespace Tests.Expenses
{
    class CreateExpense : ExpensesConfig
    {
        [Test]
        public async Task CreateExpense_CorrectData_ReturnSuccesMessage()
        {
             Expense GoodExpense1 = new Expense
             {
                 Title = "Expense21",
                 Value = 12
             };
            var Expense = await ExpensesControl.CreateExpense(GoodExpense1);
            Assert.AreEqual("Expense has been created!", Expense.SuccessMessage);
        }

        [Test]
        public async Task CreateExpense_ExpenseAddedToDatabase_RetrunTrue()
        {

            Expense GoodExpense1 = new Expense
            {
                Title = "Expense21",
                Value = 12
            };
            var Expense = await ExpensesControl.CreateExpense(GoodExpense1);
            var ExpenseCount = databaseContext.Expenses.Count();
            //one is added by default
            Assert.AreEqual(2, ExpenseCount);

        }
    }
}
