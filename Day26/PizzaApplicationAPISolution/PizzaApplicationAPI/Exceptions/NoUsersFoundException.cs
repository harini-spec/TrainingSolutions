using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoUsersFoundException : Exception
    {
        string msg;
        public NoUsersFoundException()
        {
            msg = "No customers found";
        }
        public override string Message => msg;
    }
}