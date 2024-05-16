using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
