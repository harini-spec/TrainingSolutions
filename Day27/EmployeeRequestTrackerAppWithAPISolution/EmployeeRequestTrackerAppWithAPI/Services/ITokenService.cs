using EmployeeRequestTrackerAppWithAPI.Models;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
