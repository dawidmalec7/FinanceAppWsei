using FinanceAppWsei.Controllers;
using FinanceAppWsei.Models;
using System;

namespace Tests.config
{
    public class UserVariables : DatabaseVariables
    {
        public UsersController UserControl;
        public User WrongUser = new User
        {
            Login = "test12",
            Password = "test234",
        };
        public User GoodUser = new User
        {
            Login = "test",
            Password = "test",
        };
        public User NewUser = new User
        {
            Id = new Guid(),
            FirstName = "Marcin",
            LastName = "Rybka",
            Login = "test123",
            Password = "test123",
            CreatedOn = new DateTime(),
        };
        public User ExistingUser = new User
        {
            Id = new Guid(),
            FirstName = "Dawid",
            LastName = "Malec",
            Login = "test",
            Password = "test",
            CreatedOn = new DateTime(),
        };
    }
}
