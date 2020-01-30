using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests.Expenses
{
    class DeleteExpense : ExpensesConfig
    {
        [Test]
        public async Task DeleteExpense_CorrectData_ReturnSuccessMessage()
        {    
            List<Expense> Expenses = await databaseContext.Expenses.ToListAsync();
            var ExpenseDeleted = await ExpensesControl.DeleteExpense(Expenses[0].Id);
            Assert.AreEqual("Expense has been deleted", ExpenseDeleted.SuccessMessage);
        }

        [Test]
        public async Task DeleteExpense_WrongIDExpense_ReturnProperlyMessage()
        {
            var testGuidID = new Guid();
            var ExpenseDeleted = await ExpensesControl.DeleteExpense(testGuidID);
            Assert.AreEqual("Expense with provided ID hasn't been found", ExpenseDeleted.ClientError);
        }
    }
}
