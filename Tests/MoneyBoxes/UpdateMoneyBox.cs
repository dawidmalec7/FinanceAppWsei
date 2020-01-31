using NUnit.Framework;
using System.Threading.Tasks;
using Tests.config;
using FinanceAppWsei.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests.MoneyBoxes
{
    class UpdateMoneyBoxes : MoneyBoxesConfig
    {
        [Test]
        public async Task EditMoneyBox_CorrectData_ReturnSuccessMessage()
        {
            MoneyBox MoneyBoxToUpdate = new MoneyBox
            {
                Title = "MoneyBox21",
                Value = 15
            };
            List<MoneyBox> MoneyBoxes = await databaseContext.MoneyBoxes.ToListAsync();

            var MoneyBoxUpdated = await MoneyBoxesControl.EditMoneyBox(MoneyBoxToUpdate, MoneyBoxes[0].Id);
            Assert.AreEqual("MoneyBox has been changed", MoneyBoxUpdated.SuccessMessage);
        }

        [Test]
        public async Task EditMoneyBox_WrongIDMoneyBox_ReturnProperlyMessage()
        {
            var testGuidID = new Guid();
            MoneyBox MoneyBoxToUpdate = new MoneyBox
            {
                Title = "MoneyBox21",
                Value = 15
            };
            var MoneyBoxUpdated = await MoneyBoxesControl.EditMoneyBox(MoneyBoxToUpdate, testGuidID);
            Assert.AreEqual("MoneyBox with provided ID hasn't been found", MoneyBoxUpdated.ClientError);
        }
    }
}
