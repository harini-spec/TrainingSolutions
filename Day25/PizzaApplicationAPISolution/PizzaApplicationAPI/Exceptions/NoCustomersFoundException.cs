using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoCustomersFoundException : Exception
    {
        string msg;
        public NoCustomersFoundException()
        {
            msg = "No customers found";
        }
        public override string Message => msg;
    }
}