using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoUserFoundException : Exception
    {
        string msg;
        public NoUserFoundException()
        {
            msg = "No user with given ID is found";
        }
        public override string Message => msg;
    }
}