using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoUserFoundException : Exception
    {
        string msg;
        public NoUserFoundException()
        {
            msg = "No user found with given ID";
        }
        public override string Message => msg;
    }
}