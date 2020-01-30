using FinanceAppWsei.Controllers;
using FinanceAppWsei.Models;
using System;

namespace Tests.config.Variables
{
    class IncomesVariables : DatabaseVariables
    {
        public IncomesController IncomesControl;

        public static User NewUser = new User
        {
            Id = new Guid(),
            FirstName = "Marcin",
            LastName = "Rybka",
            Login = "test123",
            Password = "test123",
            CreatedOn = new DateTime(),
        };

        public Income GoodIncome = new Income
        {
            Title = "Income",
            Value = 100,
            User = NewUser,
            UserId = NewUser.Id
        };

    }
}
