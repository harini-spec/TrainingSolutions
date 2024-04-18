using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _DepartmentRepository;
        public DepartmentBL()
        {
            _DepartmentRepository = new DepartmentRepository();
        }

        /// <summary>
        /// Adds Department 
        /// </summary>
        /// <param name="department">Department Object</param>
        /// <returns>Added Department's ID</returns>
        /// <exception cref="DuplicateDepartmentNameException">Department already exists</exception>
        public int AddDepartment(Department department)
        {
            var result = _DepartmentRepository.Add(department);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        /// <summary>
        /// Changes department name
        /// </summary>
        /// <param name="departmentOldName">Old Department Name</param>
        /// <param name="departmentNewName">New Department Name</param>
        /// <returns>Updated Department Object</returns>
        /// <exception cref="DepartmentNameDoesNotExistException">Department does not exists</exception>
        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            List<Department> departmentList = _DepartmentRepository.GetAll();
            Department department = new Department();
            for(int i=0;i<departmentList.Count;i++)
            {
                if (departmentList[i].Name == departmentOldName)
                {
                    department = departmentList[i];
                    break;
                }
            }
            department.Name = departmentNewName;
            var result = _DepartmentRepository.Update(department);
            if(result != null)
            {
                return department;
            }
            throw new DepartmentNameDoesNotExistException();
        }

        /// <summary>
        /// Gets Department Object by ID
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>Department Object</returns>
        /// <exception cref="DepartmentDoesNotExistException">Department does not exist</exception>
        public Department GetDepartmentById(int id)
        {
            var result = _DepartmentRepository.Get(id);
            if (result != null)
                return result;
            throw new DepartmentDoesNotExistException();
        }

        /// <summary>
        /// Gets Department Object by Name
        /// </summary>
        /// <param name="departmentName">Department Name</param>
        /// <returns>Department Object</returns>
        /// <exception cref="DepartmentNameDoesNotExistException">Department does not exist</exception>
        public Department GetDepartmentByName(string departmentName)
        {
            List<Department> departmentList = _DepartmentRepository.GetAll();
            for (int i = 0; i < departmentList.Count; i++)
            {
                if (departmentList[i].Name == departmentName)
                {
                    return departmentList[i];
                }
            }
            throw new DepartmentNameDoesNotExistException();
        }

        /// <summary>
        /// Gets Department Head's ID
        /// </summary>
        /// <param name="departmentId">Department ID</param>
        /// <returns>Department Head ID</returns>
        /// <exception cref="DepartmentDoesNotExistException">Department does not exist</exception>
        public int GetDepartmentHeadId(int departmentId)
        {
            Department department = _DepartmentRepository.Get(departmentId);
            if (department != null)
                return department.Department_Head;
            throw new DepartmentDoesNotExistException() ;
        }
    }
}
