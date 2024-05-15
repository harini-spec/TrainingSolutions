using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoUsersFoundException : Exception
    {
        string msg;
        public NoUsersFoundException()
        {
            msg = "No users found";
        }
        public override string Message => msg;
    }
}