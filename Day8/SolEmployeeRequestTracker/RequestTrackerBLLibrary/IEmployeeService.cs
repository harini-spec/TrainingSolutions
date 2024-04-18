using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int Id);
        List<Employee> GetEmployeeByName(string Name);
        List<Employee> GetEmployeeByType(string Type);
        List<Employee> GetEmployeeByRole(string Role);
        List<Employee> GetEmployeeInSalaryRange(int MinSalary, int MaxSalary);
        Employee ChangeEmployeeName(int EmployeeId, string NewEmployeeName);
        Employee ChangeEmployeeType(int EmployeeId, string NewType);
        Employee ChangeEmployeeRole(int EmployeeId, string NewRole);
        Employee ChangeSalary(int EmployeeId, double UpdatedSalary);
    }
}
