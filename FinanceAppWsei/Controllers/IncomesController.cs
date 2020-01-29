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
    public class IncomesController : ControllerBase
    {
        private FinanceAppContext _context;
        public IncomesController(FinanceAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Response> CreateIncome([FromBody] Income income)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            income.CreatedBy = userId;
            income.CreatedOn = DateTime.Now;
            income.UserId = userId;
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Income has been created!");
        }

        [HttpGet]
        public async Task<Response> GetIncomes()
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Income> incomes = await _context.Incomes.Where(i => i.UserId == userId).Include(i => i.Category).ToListAsync();
            return new Response(incomes);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Response> UpdateIncome([FromBody] Income income, [FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Income incomeDb = await _context.Incomes.FirstOrDefaultAsync(q => q.Id == id);

            if (incomeDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Income with provided ID hasn't been found", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            if (incomeDb.UserId != userId)
            {
                Response.StatusCode = 401;
                return new Response(clientError: "Authorization error", statusCode: System.Net.HttpStatusCode.Unauthorized);
            }

            incomeDb.Title = income.Title;
            incomeDb.Value = income.Value;
            incomeDb.CategoryId = income.CategoryId;

            _context.Incomes.Update(incomeDb);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Income has been changed");

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Response> DeleteIncome([FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Income incomeDb = await _context.Incomes.FirstOrDefaultAsync(q => q.Id == id);

            if (incomeDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Income with provided ID hasn't been found", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            if (incomeDb.UserId != userId)
            {
                Response.StatusCode = 401;
                return new Response(clientError: "Authorization error", statusCode: System.Net.HttpStatusCode.Unauthorized);
            }
            _context.Incomes.Remove(incomeDb);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Income has been deleted");

        }

    }
}