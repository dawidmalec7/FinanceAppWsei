using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinanceAppWsei.Context;
using FinanceAppWsei.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceAppWsei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private FinanceAppContext _context;
        public ExpensesController(FinanceAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Response> CreateExpense([FromBody] Expense expense)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            expense.UserId = userId;
            expense.CreatedBy = userId;
            expense.CreatedOn = DateTime.Now;
            expense.Value = expense.Value * (-1);
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Expense has been created!");
        }

        [HttpGet]
        public async Task<Response> GetExpenses()
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Expense> expenses = await _context.Expenses.Where(i => i.UserId == userId).Include(i => i.Category).ToListAsync();
            return new Response(expenses);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Response> UpdateExpense([FromBody] Expense expense, [FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Expense expenseDb = await _context.Expenses.FirstOrDefaultAsync(q => q.Id == id);

            if (expenseDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Expense with provided ID hasn't been found", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            if (expenseDb.UserId != userId)
            {
                Response.StatusCode = 401;
                return new Response(clientError: "Authorization error", statusCode: System.Net.HttpStatusCode.Unauthorized);
            }

            expenseDb.Title = expense.Title;
            expenseDb.Value = expense.Value;
            expenseDb.CategoryId = expense.CategoryId;

            _context.Expenses.Update(expenseDb);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Expense has been changed");

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Response> DeleteExpense([FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Expense expenseDb = await _context.Expenses.FirstOrDefaultAsync(q => q.Id == id);

            if (expenseDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Expense with provided ID hasn't been found", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            if (expenseDb.UserId != userId)
            {
                Response.StatusCode = 401;
                return new Response(clientError: "Authorization error", statusCode: System.Net.HttpStatusCode.Unauthorized);
            }
            _context.Expenses.Remove(expenseDb);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Expense has been deleted");

        }
    }
}
