using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoRequestsFoundException : Exception
    {
        string msg;
        public NoRequestsFoundException()
        {
            msg = "No request records are found";
        }
        public override string Message => msg;
    }
}