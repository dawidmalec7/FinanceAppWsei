using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;

namespace Tests.Users
{
    class LoginUser : UserConfig
    {
        [Test]
        public async Task LoginUser_CorrectUserData_LoginSuccesMessage()
        {
            var login = await UsersControl.LoginUser(GoodUser);
            Assert.AreEqual("You are logged in!", login.SuccessMessage);  
        }

        [Test]
        public async Task LoginUser_UncorrectUserData_LoginFailedMessage()
        {
            var login = await UsersControl.LoginUser(WrongUser);
            Assert.AreEqual("Wrong login or password!", login.ClientError);
        }

        [Test]
        public async Task LoginUser_UncorrectUserData_LoginStatusFailed()
        {
            var login = await UsersControl.LoginUser(WrongUser);
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, login.StatusCode);
        }

        [Test]
        public async Task LoginUser_CorrectUserData_ReturnAToken()
        {
            var login = await UsersControl.LoginUser(GoodUser);
            Assert.IsInstanceOf(typeof(Token), login.Data); 
        }

    }
}
