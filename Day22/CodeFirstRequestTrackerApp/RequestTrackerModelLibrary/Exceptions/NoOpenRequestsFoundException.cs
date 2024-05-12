using System.Runtime.Serialization;

namespace CodeFirstRequestTrackerApp
{
    public class NoOpenRequestsFoundException : Exception
    {
        string msg;
        public NoOpenRequestsFoundException()
        {
            msg = "No open requests found";
        }
        public override string Message => msg;
    }
}