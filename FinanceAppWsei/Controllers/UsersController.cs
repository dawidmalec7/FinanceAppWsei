using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinanceAppWsei.Context;
using FinanceAppWsei.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FinanceAppWsei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private FinanceAppContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(FinanceAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("register")]
        public async Task<Response> RegisterUser([FromBody] User user)
        {
            User userDb = await _context.Users.FirstOrDefaultAsync(u => u.Login == user.Login);
            if (userDb != null)
            {
                //Response.StatusCode = 400;
                return new Models.Response(clientError: "Użytkownik o takim loginie już istnieje", statusCode: System.Net.HttpStatusCode.BadRequest);
            }

            user.CreatedOn = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new Models.Response(successMessage: "Konto zostało założone możesz się zalogować");
        }

        [HttpPost]
        [Route("login")]
        public async Task<Response> LoginUser([FromBody] User user)
        {
            User userDb = await _context.Users.FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);
            if (userDb == null)
            {
                //Response.StatusCode = 400;
                return new Models.Response(clientError: "Błędny login lub hasło", statusCode: System.Net.HttpStatusCode.BadRequest);
            }
            return new Models.Response(GenerateToken(userDb), successMessage: "Udało się zalogować");
        }

        private object GenerateToken(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "User"),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var lifeTime = DateTime.Now.AddDays(30);
            var token = new JwtSecurityToken(issuer: "localhost:44310", audience: "localhost:44310", claims: claims, expires: lifeTime, signingCredentials: creds);

            return new Models.Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                LifeTime = lifeTime
            };
        }
    }
}