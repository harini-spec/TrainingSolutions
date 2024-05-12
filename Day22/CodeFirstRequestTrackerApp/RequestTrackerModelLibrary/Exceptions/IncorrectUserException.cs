using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class IncorrectUserException : Exception
    {
        string msg;
        public IncorrectUserException()
        {
            msg = "You are not authorized";
        }
        public override string Message => msg;
    }
}