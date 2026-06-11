using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Petrol_Pump_Web_API.DomainLayer.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Petrol_Pump_Web_API.ApplicationLayer.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string>  Authenticate(string username, string password)
        {
            var user= _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password==password);


            if (user == null)
            {
                return null;
            }



            return GenerateToken(username);



        }

        private string GenerateToken(string username)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
