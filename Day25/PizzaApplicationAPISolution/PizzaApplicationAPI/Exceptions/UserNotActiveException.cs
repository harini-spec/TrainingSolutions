using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class UserNotActiveException : Exception
    {
        string msg;
        public UserNotActiveException()
        {
            msg = "User not activated yet";
        }
        public override string Message => msg;
    }
}