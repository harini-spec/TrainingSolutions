using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class RequestAlreadyClosedException : Exception
    {
        string msg;
        public RequestAlreadyClosedException(string ClosedByEmployee)
        {
            msg = "Request already Closed by " + ClosedByEmployee;
        }
        public override string Message => msg;
    }
}