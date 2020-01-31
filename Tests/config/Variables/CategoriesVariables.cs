using FinanceAppWsei.Controllers;
using FinanceAppWsei.Models;
using System;

namespace Tests.config
{
    class CategoriesVariables : DatabaseVariables
    {
        public CategoriesController CategoriesControl;

        public static User NewUser = new User
        {
            Id = new Guid(),
            FirstName = "Marcin",
            LastName = "Rybka",
            Login = "test123",
            Password = "test123",
            CreatedOn = new DateTime(),
        };

        public Category TestCategory = new Category
        {
            Title = "TestCategory",
        };
    }
}
