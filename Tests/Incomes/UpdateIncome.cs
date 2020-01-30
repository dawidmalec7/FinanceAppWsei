using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests.Incomes
{
    class UpdateExpenses : IncomesConfig
    {
        [Test]
        public async Task EditIncome_CorrectData_ReturnSuccessMessage()
        {
            List<Income> incomes = await databaseContext.Incomes.ToListAsync();

             Income incomeToUpdate = new Income
             {
                 Title = "Income21",
                 Value = 15
             };

            var incomeUpdated = await IncomesControl.UpdateIncome(incomeToUpdate, incomes[0].Id);
            Assert.AreEqual("Income has been changed", incomeUpdated.SuccessMessage);
        }

        [Test]
        public async Task EditIncome_WrongIDIncome_ReturnProperlyMessage()
        {
            var testGuidID = new Guid();
            Income incomeToUpdate = new Income
            {
                Title = "Income21",
                Value = 15
            };
            var incomeUpdated = await IncomesControl.UpdateIncome(incomeToUpdate, testGuidID);
            Assert.AreEqual("Income with provided ID hasn't been found", incomeUpdated.ClientError);
        }
    }
}
