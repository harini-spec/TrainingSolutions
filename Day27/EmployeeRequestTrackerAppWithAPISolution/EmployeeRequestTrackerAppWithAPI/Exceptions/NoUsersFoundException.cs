using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class NoUsersFoundException : Exception
    {
        string msg;
        public NoUsersFoundException()
        {
            msg = "No user records found";
        }
        public override string Message => msg;
    }
}