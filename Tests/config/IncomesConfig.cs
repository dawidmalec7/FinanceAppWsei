using NUnit.Framework;
using System;
using FinanceAppWsei.Models;
using FinanceAppWsei.Controllers;
using Tests.config.Variables;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Tests.config
{
    class IncomesConfig : IncomesVariables
    {
        [SetUp]
        public void Setup()
        {
            SetupDB();
            var userClaimsTypes = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "b766fcac-3141-4bd0-bd96-ac714de9db38"),
                }, "mock"));

            IncomesControl = new IncomesController(databaseContext);

            IncomesControl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaimsTypes }
            };
        }
    }
}
