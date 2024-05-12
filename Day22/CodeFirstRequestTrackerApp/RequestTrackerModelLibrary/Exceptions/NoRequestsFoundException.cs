using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class NoRequestsFoundException : Exception
    {
        string msg;
        public NoRequestsFoundException()
        {
            msg = "No requests were raised";
        }
        public override string Message => msg;
    }
}