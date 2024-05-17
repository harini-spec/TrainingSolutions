using EmployeeRequestTrackerAppWithAPI.Models.DTOs;
using EmployeeRequestTrackerAppWithAPI.Models;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<RegisterDTO> Register(RegisterInputDTO employeeDTO);
        public Task<ActivatingUserOutput> ActivateUser(ActivatingUserInput activatingUserInput, int ActivatingUserId);
    }
}
