using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;

namespace Tests.MoneyBoxes
{
    class GetMoneyBoxes : MoneyBoxesConfig
    {
        [Test]
        public async Task GetMoneyBoxes_CorrectData_ReturnResponseObject()
        {
            var getMoneyBoxes = await MoneyBoxesControl.GetMoneyBoxes();
            Assert.IsInstanceOf(typeof(Response), getMoneyBoxes);
        }

        [Test]
        public async Task GetMoneyBoxes_CorrectData_ReturnListOfMoneyBoxes()
        {
           var getMoneyBoxes = await MoneyBoxesControl.GetMoneyBoxes();
           Assert.IsInstanceOf(typeof(List<MoneyBox>), getMoneyBoxes.Data);
        }

    }
}
