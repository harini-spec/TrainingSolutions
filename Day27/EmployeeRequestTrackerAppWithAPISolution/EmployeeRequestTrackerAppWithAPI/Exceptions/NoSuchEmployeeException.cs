using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string msg;
        public NoSuchEmployeeException()
        {
            msg = "No such employee found";
        }
        public override string Message => msg;
    }
}