using EmployeeRequestTrackerAppWithAPI.Contexts;
using EmployeeRequestTrackerAppWithAPI.Exceptions;
using EmployeeRequestTrackerAppWithAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAppWithAPI.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await GetById(key);
            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            throw new NoSuchEmployeeException();
        }

        public async Task<Employee> GetById(int key)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll ()
        {
            var employees = await _context.Employees.ToListAsync();
            if(employees.Count==0)
                throw new NoEmployeesFoundException();
            return employees;

        }

        public async Task<Employee> Update(Employee item)
        {
            var employee = await GetById(item.Id);
            if (employee != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return employee;
            }
            throw new NoSuchEmployeeException();
        }
    }
}
