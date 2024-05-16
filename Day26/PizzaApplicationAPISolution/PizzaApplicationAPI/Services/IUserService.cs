using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Models.DTOs;

namespace PizzaApplicationAPI.Services
{
    public interface IUserService
    {
        public Task<User> Register(UserRegisterDTO RegisterDTO);
        public Task<LoginReturnDTO> Login(UserLoginDTO LoginDTO);
    }
}
