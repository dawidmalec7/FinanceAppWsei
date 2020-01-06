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
    public class MoneyBoxesController : ControllerBase
    {
        private FinanceAppContext _context;
        public MoneyBoxesController(FinanceAppContext context)
        {
            _context = context;
        }

        [HttpPost] 
        public async Task<Response> AddNewMoneyBox([FromBody] MoneyBox moneyBox)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            moneyBox.UserId = userId;
            moneyBox.CreatedOn = DateTime.Now;

            _context.MoneyBoxes.Add(moneyBox);
            await _context.SaveChangesAsync();

            return new Response(successMessage: "Skarbonka została dodana");
        }

        [HttpGet]
        public async Task<Response> GetMoneyBoxes()
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<MoneyBox> moneyBoxes = await _context.MoneyBoxes.Where(q => q.UserId == userId).ToListAsync();
            moneyBoxes.ForEach(mb => mb.Value = (_context.Incomes.Where(i => i.MoneyBoxId == mb.Id).Select(i => i.Value).Sum() + _context.Expenses.Where(i => i.MoneyBoxId == mb.Id).Select(i => i.Value).Sum()) * (-1));

            return new Response(moneyBoxes);
        }

        [HttpPut] 
        [Route("{id}")]
        public async Task<Response> EditMoneyBox([FromBody] MoneyBox moneyBox, [FromRoute] Guid id) 
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            MoneyBox moneyBoxDb = await _context.MoneyBoxes.FirstOrDefaultAsync(mb => mb.Id == id);
            if (moneyBoxDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Skarbonka o podanym ID nie zostało znalezione", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            if (moneyBoxDb.UserId != userId)
            {
                Response.StatusCode = 401;
                return new Response(clientError: "Nie posiadasz wystarczających uprawnień żeby zarządzać skarbonką", statusCode: System.Net.HttpStatusCode.Unauthorized);
            }

            moneyBoxDb.Title = moneyBox.Title;
            moneyBoxDb.Target = moneyBox.Target;

            _context.MoneyBoxes.Update(moneyBoxDb);
            await _context.SaveChangesAsync();

            return new Response(successMessage: "Skarbonka została zmieniona");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Response> DeleteMoneyBox([FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            MoneyBox moneyBox = await _context.MoneyBoxes.FirstOrDefaultAsync(mb => mb.Id == id);
            if (moneyBox == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Skarbonka o podanym ID nie zostało znalezione", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            if (moneyBox.UserId != userId)
            {
                Response.StatusCode = 401;
                return new Response(clientError: "Nie posiadasz wystarczających uprawnień żeby zarządzać skarbonką", statusCode: System.Net.HttpStatusCode.Unauthorized);
            }

            moneyBox.Value = (_context.Incomes.Where(i => i.MoneyBoxId == id).Select(i => i.Value).Sum() + _context.Expenses.Where(i => i.MoneyBoxId == id).Select(i => i.Value).Sum()) * (-1);

            Income income = new Income()
            {
                Title = "Usunięcie skarbonki " + moneyBox.Title,
                Value = moneyBox.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = userId
            };

            _context.Incomes.Add(income);
            _context.MoneyBoxes.Remove(moneyBox);

            await _context.SaveChangesAsync();
            return new Response(successMessage: "Skarbonka została usunięta");
        }
    }
}