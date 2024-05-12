using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class NoFeedbacksFoundException : Exception
    {
        string msg;
        public NoFeedbacksFoundException()
        {
            msg = "No feedbacks were found!";
        }
        public override string Message => msg; 

    }
}