using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;
using System;

namespace Tests.Accounts
{
    class GetAccountBalance : AccountsConfig
    {
        [Test]
        public async Task GetACcountBalance_AddIncomeAndExpense_ReturnCorrectBalance()
        {

             Income TestIncome = new Income
             {
                 Title = "Income",
                 Value = 100
             };

            Expense TestExpense = new Expense
                {
                    Title = "Expense21",
                    Value = 10
                };

            var Income = await IncomesControl.CreateIncome(TestIncome);
            var Expense = await ExpensesControl.CreateExpense(TestExpense);

            var Balance = await AccountsControl.GetAccountBalance();
            Assert.AreEqual(90, Balance.Data);
        }

    
    }
}
