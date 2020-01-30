using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests.Incomes
{
    class DeleteIncome : IncomesConfig
    {
        [Test]
        public async Task DeleteIncome_CorrectData_ReturnSuccessMessage()
        {    
            List<Income> incomes = await databaseContext.Incomes.ToListAsync();
            var incomeDeleted = await IncomesControl.DeleteIncome(incomes[0].Id);
            Assert.AreEqual("Income has been deleted", incomeDeleted.SuccessMessage);
        }

        [Test]
        public async Task DeleteIncome_WrongIDIncome_ReturnProperlyMessage()
        {
            var testGuidID = new Guid();
            var incomeDeleted = await IncomesControl.DeleteIncome(testGuidID);
            Assert.AreEqual("Income with provided ID hasn't been found", incomeDeleted.ClientError);
        }
    }
}
