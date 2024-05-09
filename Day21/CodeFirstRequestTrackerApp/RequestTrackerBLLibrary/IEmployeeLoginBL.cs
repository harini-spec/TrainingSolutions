using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeLoginBL
    {
        public Task<Employee> GetEmployee(int id);
        public Task<bool> Login(RequestTrackerModelLibrary.Employee employee);
        public Task<RequestTrackerModelLibrary.Employee> Register(RequestTrackerModelLibrary.Employee employee);
    }
}