using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;

namespace Tests.Incomes
{
    class GetExpense : IncomesConfig
    {
        [Test]
        public async Task GetIncomes_CorrectData_ReturnResponseObject()
        {
            var getIncomes = await IncomesControl.GetIncomes();
            Assert.IsInstanceOf(typeof(Response), getIncomes);
        }

        [Test]
        public async Task GetIncomes_CorrectData_ReturnListOfIncomes()
        {
           var getIncomes = await IncomesControl.GetIncomes();
           Assert.IsInstanceOf(typeof(List<Income>), getIncomes.Data);
        }

    }
}
