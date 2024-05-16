using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoUserFoundException : Exception
    {
        string msg;
        public NoUserFoundException()
        {
            msg = "No customer with given ID present";
        }
        public override string Message => msg;
    }
}