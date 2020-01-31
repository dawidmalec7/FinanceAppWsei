using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;
using System.Linq;

namespace Tests.MoneyBoxes
{
    class CreateMoneyBoxes : MoneyBoxesConfig
    {
        [Test]
        public async Task CreateMoneyBoxes_CorrectData_ReturnSuccesMessage()
        {
             MoneyBox GoodMoneyBoxes1 = new MoneyBox
             {
                 Title = "MoneyBoxes21",
                 Value = 12
             };
            var MoneyBoxes = await MoneyBoxesControl.AddNewMoneyBox(GoodMoneyBoxes1);
            Assert.AreEqual("MoneyBoxes has been created!", MoneyBoxes.SuccessMessage);
        }

        [Test]
        public async Task CreateMoneyBoxes_MoneyBoxesAddedToDatabase_RetrunTrue()
        {

            MoneyBox GoodMoneyBoxes1 = new MoneyBox
            {
                Title = "MoneyBoxes21",
                Value = 12
            };
            var MoneyBoxes = await MoneyBoxesControl.AddNewMoneyBox(GoodMoneyBoxes1);
            var MoneyBoxesCount = databaseContext.MoneyBoxes.Count();
            Assert.AreEqual(2, MoneyBoxesCount);

        }
    }
}
