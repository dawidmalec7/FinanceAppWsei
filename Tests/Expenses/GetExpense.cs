using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;

namespace Tests.Expenses
{
    class GetExpense : ExpensesConfig
    {
        [Test]
        public async Task GetExpenses_CorrectData_ReturnResponseObject()
        {
            var getExpenses = await ExpensesControl.GetExpenses();
            Assert.IsInstanceOf(typeof(Response), getExpenses);
        }

        [Test]
        public async Task GetExpenses_CorrectData_ReturnListOfExpenses()
        {
           var getExpenses = await ExpensesControl.GetExpenses();
           Assert.IsInstanceOf(typeof(List<Expense>), getExpenses.Data);
        }

    }
}
