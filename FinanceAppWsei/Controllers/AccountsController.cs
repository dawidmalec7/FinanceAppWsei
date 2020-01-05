using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinanceAppWsei.Context;
using FinanceAppWsei.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceAppWsei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private FinanceAppContext _context;
        public AccountsController(FinanceAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<Response> GetAccountBalance()
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            double incomes = await _context.Incomes.Where(i => i.UserId == userId).Select(i => i.Value).SumAsync();
            double expenses = await _context.Expenses.Where(i => i.UserId == userId).Select(i => i.Value).SumAsync();

            double accountBalance = incomes + expenses;

            return new Response(accountBalance);
        }
    }
}