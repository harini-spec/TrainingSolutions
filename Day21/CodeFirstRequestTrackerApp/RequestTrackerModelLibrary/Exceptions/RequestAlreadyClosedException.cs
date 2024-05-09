using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class RequestAlreadyClosedException : Exception
    {
        string msg;
        public RequestAlreadyClosedException(int? EmployeeId)
        {
            msg = "Request is already closed by " + EmployeeId;
        }
        public override string Message => msg;
    }
}