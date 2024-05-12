using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class EmployeeDoesNotExistException : Exception
    {
        string msg;
        public EmployeeDoesNotExistException()
        {
            msg = "Employee does not exist";
        }
        public override string Message => msg;
    }
}