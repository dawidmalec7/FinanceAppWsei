using FinanceAppWsei.Controllers;
using FinanceAppWsei.Models;
using System;

namespace Tests.config.Variables
{
    class ExpensesVariables : DatabaseVariables
    {
        public ExpensesController ExpensesControl;

        public static User NewUser = new User
        {
            Id = new Guid(),
            FirstName = "Marcin",
            LastName = "Rybka",
            Login = "test123",
            Password = "test123",
            CreatedOn = new DateTime(),
        };

        public Expense GoodExpense = new Expense
        {
            Title = "Expense",
            Value = 100
        };
    }
}
