using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class UnableToRegisterException : Exception
    {
        string msg;
        public UnableToRegisterException()
        {
            msg = "Unable to register at this moment";
        }
        public override string Message => msg;
    }
}