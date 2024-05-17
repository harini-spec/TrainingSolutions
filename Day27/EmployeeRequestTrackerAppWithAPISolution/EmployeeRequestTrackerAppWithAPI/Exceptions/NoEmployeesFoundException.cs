using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoEmployeesFoundException : Exception
    {
        string msg;
        public NoEmployeesFoundException()
        {
            msg = "No employees found";
        }
        public override string Message => msg;
    }
}