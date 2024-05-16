using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoUserCredentialFoundException : Exception
    {
        string msg;
        public NoUserCredentialFoundException()
        {
            msg = "No user found with given ID";
        }
        public override string Message => msg;
    }
}