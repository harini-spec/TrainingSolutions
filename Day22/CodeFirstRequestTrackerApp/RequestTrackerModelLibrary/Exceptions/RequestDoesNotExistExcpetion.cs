using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class RequestDoesNotExistException : Exception
    {
        string msg;
        public RequestDoesNotExistException()
        {
            msg = "Request does not exist";
        }
        public override string Message => msg;
    }
}