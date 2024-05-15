using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoCustomerFoundException : Exception
    {
        string msg;
        public NoCustomerFoundException()
        {
            msg = "No customer with given ID present";
        }
        public override string Message => msg;
    }
}