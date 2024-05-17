using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoRequestFoundException : Exception
    {
        string msg;
        public NoRequestFoundException()
        {
            msg = "No request with given ID is found";
        }
        public override string Message => msg;
    }
}