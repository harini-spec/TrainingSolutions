using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Models.DTOs;

namespace PizzaApplicationAPI.Services
{
    public interface IUserService
    {
        public Task<Customer> Register(CustomerRegisterDTO RegisterDTO);
        public Task<Customer> Login(CustomerLoginDTO LoginDTO);
    }
}
