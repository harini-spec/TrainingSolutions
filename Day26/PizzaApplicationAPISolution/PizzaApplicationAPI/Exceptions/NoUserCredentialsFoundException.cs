using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoUserCredentialsFoundException : Exception
    {
        string msg;
        public NoUserCredentialsFoundException()
        {
            msg = "No users found";
        }
        public override string Message => msg;
    }
}