using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class NoRequestSolutionFoundException : Exception
    {
        string msg;
        public NoRequestSolutionFoundException()
        {
            msg = "No solutions found";
        }
        public override string Message => msg;
    }
}