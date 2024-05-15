using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        string msg;
        public UnauthorizedUserException()
        {
            msg = "Invalid username or password";
        }
        public override string Message => msg;
    }
}