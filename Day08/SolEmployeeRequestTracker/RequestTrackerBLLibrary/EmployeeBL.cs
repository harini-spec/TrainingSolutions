using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _EmployeeRepository ;
        public EmployeeBL() 
        {
            _EmployeeRepository = new EmployeeRepository();
        }

        /// <summary>
        /// Adds Employee
        /// </summary>
        /// <param name="employee">Employee Object</param>
        /// <returns>Added Employee's ID as int</returns>
        /// <exception cref="EmployeeAlreadyExistsException">Employee record already exists</exception>
        public int AddEmployee(Employee employee)
        {
            var result = _EmployeeRepository.Add(employee);
            if (result != null)
                return result.Id;
            throw new EmployeeAlreadyExistsException();
        }

        /// <summary>
        /// Changes Employee's name
        /// </summary>
        /// <param name="EmployeeId">Employee ID</param>
        /// <param name="EmployeeNewName">Employee's new name</param>
        /// <returns>Updated Employee Object</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public Employee ChangeEmployeeName(int EmployeeId, string EmployeeNewName)
        {
            var Employee = _EmployeeRepository.Get(EmployeeId);
            if(Employee != null)
            {
                Employee.Name = EmployeeNewName;
                var result = _EmployeeRepository.Update(Employee);
                return result;
            }
            throw new EmployeeNotFoundException();
        }

        /// <summary>
        /// Changes Employee's role
        /// </summary>
        /// <param name="EmployeeId">Employee ID</param>
        /// <param name="NewRole">Employee's new role</param>
        /// <returns>Updated Employee Object</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public Employee ChangeEmployeeRole(int EmployeeId, string NewRole)
        {
            var Employee = _EmployeeRepository.Get(EmployeeId);
            if (Employee != null)
            {
                Employee.Role = NewRole;
                var result = _EmployeeRepository.Update(Employee);
                return result;
            }
            throw new EmployeeNotFoundException();
        }

        /// <summary>
        /// Changes Employee's type
        /// </summary>
        /// <param name="EmployeeId">Employee ID</param>
        /// <param name="NewType">Employee's new work type</param>
        /// <returns>Updated Employee Object</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public Employee ChangeEmployeeType(int EmployeeId, string NewType)
        {
            var Employee = _EmployeeRepository.Get(EmployeeId);
            if (Employee != null)
            {
                Employee.Type = NewType;
                var result = _EmployeeRepository.Update(Employee);
                return result;
            }
            throw new EmployeeNotFoundException();
        }

        /// <summary>
        /// Changes Employee's Salary
        /// </summary>
        /// <param name="EmployeeId">Employee ID</param>
        /// <param name="UpdatedSalary">Employee's new salary</param>
        /// <returns>Updated Employee Object</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public Employee ChangeSalary(int EmployeeId, double UpdatedSalary)
        {
            var Employee = _EmployeeRepository.Get(EmployeeId);
            if (Employee != null)
            {
                Employee.Salary = UpdatedSalary;
                var result = _EmployeeRepository.Update(Employee);
                return result;
            }
            throw new EmployeeNotFoundException();
        }

        /// <summary>
        /// Gets Employee record by ID
        /// </summary>
        /// <param name="Id">Employee ID</param>
        /// <returns>Employee object</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public Employee GetEmployeeById(int Id)
        {
            var Employee = _EmployeeRepository.Get(Id);
            return Employee != null ? Employee : throw new EmployeeNotFoundException();
        }

        /// <summary>
        /// Gets Employee record by Name
        /// </summary>
        /// <param name="Name">Employee Name</param>
        /// <returns>List of Employee objects</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public List<Employee> GetEmployeeByName(string Name)
        {
            List<Employee> Employees = _EmployeeRepository.GetAll();
            List<Employee> EmployeesWithGivenName = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if(employee.Name == Name)
                    EmployeesWithGivenName.Add(employee);
            }
            if(EmployeesWithGivenName.Count == 0) 
            {
                throw new EmployeeNotFoundException();
            }
            return EmployeesWithGivenName;
        }

        /// <summary>
        /// Gets Employee record by Role
        /// </summary>
        /// <param name="Role">Employee Role</param>
        /// <returns>List of Employee objects</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public List<Employee> GetEmployeeByRole(string Role)
        {
            List<Employee> Employees = _EmployeeRepository.GetAll();
            List<Employee> EmployeesWithGivenRole = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if (employee.Role == Role)
                    EmployeesWithGivenRole.Add(employee);
            }
            if (EmployeesWithGivenRole.Count == 0)
            {
                throw new EmployeeNotFoundException();
            }
            return EmployeesWithGivenRole;
        }

        /// <summary>
        /// Gets Employee record by Type
        /// </summary>
        /// <param name="Type">Employee Type</param>
        /// <returns>List of Employee objects</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public List<Employee> GetEmployeeByType(string Type)
        {
            List<Employee> Employees = _EmployeeRepository.GetAll();
            List<Employee> EmployeesWithGivenType = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if (employee.Type == Type)
                    EmployeesWithGivenType.Add(employee);
            }
            if (EmployeesWithGivenType.Count == 0)
            {
                throw new EmployeeNotFoundException();
            }
            return EmployeesWithGivenType;
        }

        /// <summary>
        /// Gets Employee records in the given salary range
        /// </summary>
        /// <param name="MinSalary">Min Salary of the range</param>
        /// <param name="MaxSalary">Max Salary of the range</param>
        /// <returns>List of Employee Objects</returns>
        /// <exception cref="EmployeeNotFoundException">Employee doesn't exist</exception>
        public List<Employee> GetEmployeeInSalaryRange(int MinSalary, int MaxSalary)
        {
            List<Employee> Employees = _EmployeeRepository.GetAll();
            List<Employee> EmployeesInSalaryRange = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if (employee.Salary > MinSalary && employee.Salary < MaxSalary)
                    EmployeesInSalaryRange.Add(employee);
            }
            if (EmployeesInSalaryRange.Count == 0)
            {
                throw new EmployeeNotFoundException();
            }
            return EmployeesInSalaryRange;
        }
    }
}
