using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoOpenRequestsFoundException : Exception
    {
        string msg;
        public NoOpenRequestsFoundException()
        {
            msg = "No open requests found";
        }
    }
}