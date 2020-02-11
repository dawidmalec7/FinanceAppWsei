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
    public class CategoriesController : ControllerBase
    {
        private FinanceAppContext _context;
        public CategoriesController(FinanceAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<Response> GetCategories()
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Category> categories = await _context.Categories.Where(q => q.CreatedBy == userId).ToListAsync();

            return new Response(categories);
        }

        [HttpPost]
        public async Task<Response> AddCategory([FromBody] Category category)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            category.CreatedBy = userId;
            category.CreatedOn = DateTime.Now;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Category has been created!"); 
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Response> EditCategory([FromBody] Category category, [FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Category categoryDb = await _context.Categories.FirstOrDefaultAsync(q => q.Id == id && q.CreatedBy == userId);
            if(categoryDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Category with provided ID hasn't been found", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            categoryDb.Title = category.Title;
            _context.Categories.Update(categoryDb);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Category has been changed");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Response> DeleteCategory([FromRoute] Guid id)
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Category categoryDb = await _context.Categories.FirstOrDefaultAsync(q => q.Id == id);

            if (categoryDb == null)
            {
                Response.StatusCode = 400;
                return new Response(clientError: "Category with provided ID hasn't been found", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            _context.Categories.Remove(categoryDb);
            await _context.SaveChangesAsync();
            return new Response(successMessage: "Category has been deleted");

        }
    }
}