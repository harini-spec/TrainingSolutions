using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        readonly Dictionary<int, Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new Dictionary<int, Employee>();
        }

        /// <summary>
        /// Generates ID automatically for new Employee entry 
        /// </summary>
        /// <returns>ID as int</returns>
        public int GenerateId()
        {
            int id = _employees.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Adds new Employee entry to Employee Dictionary
        /// </summary>
        /// <param name="item">Employee Object</param>
        /// <returns>Inserted Employee Object</returns>
        public Employee Add(Employee item)
        {
            if (_employees.ContainsValue(item))
                return null;
            int Id = GenerateId();
            item.Id = Id;
            _employees.Add(Id, item);
            return _employees[Id];
        }

        /// <summary>
        /// Deletes the Employee entry of given ID
        /// </summary>
        /// <param name="key">Employee ID</param>
        /// <returns>Deleted Employee Object if present, else null</returns>
        public Employee Delete(int key)
        {
            if (_employees.ContainsKey(key))
            {
                var Employee = _employees[key];
                _employees.Remove(key);
                return Employee;
            }
            return null;
        }

        /// <summary>
        /// Gets Employee entry of given ID
        /// </summary>
        /// <param name="key">Employee ID</param>
        /// <returns>Employee Object if present, else null</returns>
        public Employee Get(int key)
        {
            return _employees.ContainsKey(key) ? _employees[key] : null;
        }

        /// <summary>
        /// Gets all Employee entries
        /// </summary>
        /// <returns>List of Employee Objects</returns>
        public List<Employee> GetAll()
        {
            if (_employees.Count == 0)
                return null;
            return _employees.Values.ToList();
        }

        /// <summary>
        /// Updates the given Employee object in the dictionary 
        /// </summary>
        /// <param name="item">Updated Employee object</param>
        /// <returns>Updated Employee object if present, else null</returns>
        public Employee Update(Employee item)
        {
            if (_employees.ContainsKey(item.Id))
            {
                _employees[item.Id] = item;
                return _employees[item.Id];
            }
            return null;
        }
    }
}
