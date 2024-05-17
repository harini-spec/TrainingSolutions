using EmployeeRequestTrackerAppWithAPI.Exceptions;
using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Repositories;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public class EmployeeBasicService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeBasicService(IRepository<int, Employee> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.GetAll()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _repository.GetAll();
                return employees;
            }
            catch(NoEmployeesFoundException nefe)
            {
                throw new NoEmployeesFoundException();
            }
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
