using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests.Expenses
{
    class UpdateExpenses : ExpensesConfig
    {
        [Test]
        public async Task EditExpense_CorrectData_ReturnSuccessMessage()
        {
            List<Expense> Expenses = await databaseContext.Expenses.ToListAsync();

             Expense ExpenseToUpdate = new Expense
             {
                 Title = "Expense21",
                 Value = 15
             };

            var ExpenseUpdated = await ExpensesControl.UpdateExpense(ExpenseToUpdate, Expenses[0].Id);
            Assert.AreEqual("Expense has been changed", ExpenseUpdated.SuccessMessage);
        }

        [Test]
        public async Task EditExpense_WrongIDExpense_ReturnProperlyMessage()
        {
            var testGuidID = new Guid();
            Expense ExpenseToUpdate = new Expense
            {
                Title = "Expense21",
                Value = 15
            };
            var ExpenseUpdated = await ExpensesControl.UpdateExpense(ExpenseToUpdate, testGuidID);
            Assert.AreEqual("Expense with provided ID hasn't been found", ExpenseUpdated.ClientError);
        }
    }
}
