﻿using FinanceAppWsei.Controllers;
using FinanceAppWsei.Models;
using System;

namespace Tests.config.Variables
{
    class MoneyBoxesVariables : DatabaseVariables
    {
        public MoneyBoxesController MoneyBoxesControl;

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
            Value = 100
        };
    }
}
