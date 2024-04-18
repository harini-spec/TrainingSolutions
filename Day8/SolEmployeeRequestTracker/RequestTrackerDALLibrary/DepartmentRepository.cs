using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        readonly Dictionary<int, Department> _departments;
        public DepartmentRepository()
        {
            _departments = new Dictionary<int, Department>();
        }

        /// <summary>
        /// Generates ID automatically for new Department entry 
        /// </summary>
        /// <returns>ID as int</returns>
        int GenerateId()
        {
            if (_departments.Count == 0)
                return 1;
            int id = _departments.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Adds new Department entry to Department Dictionary
        /// </summary>
        /// <param name="item">Department Object</param>
        /// <returns>Inserted Department Object</returns>
        public Department Add(Department item)
        {
            if (_departments.ContainsValue(item))
            {
                return null;
            }
            int Id = GenerateId();
            item.Id = Id;
            _departments.Add(Id, item);
            return item;
        }

        /// <summary>
        /// Deletes the Department entry of given ID
        /// </summary>
        /// <param name="key">Department ID</param>
        /// <returns>Deleted Department Object if present, else null</returns>
        public Department Delete(int key)
        {
            if (_departments.ContainsKey(key))
            {
                var department = _departments[key];
                _departments.Remove(key);
                return department;
            }
            return null;
        }

        /// <summary>
        /// Gets Department entry of given ID
        /// </summary>
        /// <param name="key">Department ID</param>
        /// <returns>Department Object if present, else null</returns>
        public Department Get(int key)
        {
            return _departments.ContainsKey(key) ? _departments[key] : null;
        }

        /// <summary>
        /// Gets all Department entries
        /// </summary>
        /// <returns>List of Department Objects</returns>
        public List<Department> GetAll()
        {
            if (_departments.Count == 0)
                return null;
            return _departments.Values.ToList();
        }

        /// <summary>
        /// Updates the given Department object in the dictionary 
        /// </summary>
        /// <param name="item">Updated Department object</param>
        /// <returns>Updated department object if present, else null</returns>
        public Department Update(Department item)
        {
            if (_departments.ContainsKey(item.Id))
            {
                _departments[item.Id] = item;
                return _departments[item.Id];
            }
            return null;
        }
    }
}
