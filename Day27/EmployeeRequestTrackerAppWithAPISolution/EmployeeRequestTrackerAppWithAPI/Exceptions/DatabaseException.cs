using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAppWithAPI.Exceptions
{
    public class DatabaseException : Exception
    {
        string msg;
        public DatabaseException()
        {
            msg = "Exception occurred while saving to the Database";
        }
        public override string Message => msg;
    }
}