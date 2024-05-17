using EmployeeRequestTrackerAppWithAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        // injection to get key from appsettings 
        public TokenService(IConfiguration configuration)       
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();

            // encode the key using symmetric key (same key on both sides)
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));                   
        }
        public string GenerateToken(Employee employee)
        {
            string token = string.Empty;

            // payload
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name, employee.Id.ToString()),
                new Claim(ClaimTypes.Role, employee.Role.ToString())
            };
            
            // algo to encrypt token
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            // audience -- who can login to the application 
            // issuer   -- for now, no issuer like google -- we are creating our own so we r the issuer - keep it as null
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials); // generate token with overloaded method 
                   
            token = new JwtSecurityTokenHandler().WriteToken(myToken); // convert token to string
            return token;
        }
    }
}
