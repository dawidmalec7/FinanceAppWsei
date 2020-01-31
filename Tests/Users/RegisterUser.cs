using NUnit.Framework;
using FinanceAppWsei.Models;
using System.Threading.Tasks;
using Tests.config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tests.Users
{
    class RegisterUser : UserConfig
    {
        [Test]
        public async Task RegisterUser_CorrectUserData_ReturnSuccesMessage()
        {
            var register = await UsersControl.RegisterUser(NewUser);
            Assert.AreEqual("Success! You can log in now!", register.SuccessMessage);
        }

        [Test]
        public async Task RegisterUser_AlreadyUsedUserlogin_ReturnErrorMessage()
        {
            var register = await UsersControl.RegisterUser(ExistingUser);
            Assert.AreEqual("User already exist.", register.ClientError);
        }
        [Test]
        public async Task RegisterUser_UserAddedToDatabase_ReturnTrue()
        {
         
            var register = await UsersControl.RegisterUser(NewUser);
            var usersCount = databaseContext.Users.Count();
            // 2 - because there is added one by default
            Assert.AreEqual(2, usersCount);
        }
        [Test]
        public async Task RegisterUser_UncorrectUserData_ReturnStatusBadRequest()
        {
            var register = await UsersControl.RegisterUser(ExistingUser);
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, register.StatusCode);
        }
    }
}
