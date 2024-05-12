using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class RequestAlreadyClosedException : Exception
    {
        string msg;

        public RequestAlreadyClosedException()
        {
        }

        public RequestAlreadyClosedException(string? EmployeeName)
        {
            msg = "Request is already closed by " + EmployeeName;
        }
        public override string Message => msg;
    }
}