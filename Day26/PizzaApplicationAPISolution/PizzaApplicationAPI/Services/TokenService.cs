using Microsoft.IdentityModel.Tokens;
using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaApplicationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretkey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration) 
        {
            _secretkey = configuration.GetSection("Token").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey));
        }
        public string GenerateToken(User user)
        {
            string token = string.Empty;

            var claims = new List<Claim>()
            {
                new Claim("UId", user.Id.ToString())
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var myToken = new JwtSecurityToken(null, null, claims, expires : DateTime.Now.AddDays(1), signingCredentials : credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);

            return token;
        }
    }
}
