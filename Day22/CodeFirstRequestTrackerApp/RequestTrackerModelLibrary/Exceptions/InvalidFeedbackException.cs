using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class InvalidFeedbackException : Exception
    {
        string msg;
        public InvalidFeedbackException()
        {
            msg = "Invalid feedback. Please provide correct input";
        }

        public override string Message => msg; 
    }
}