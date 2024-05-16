using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoPizzaFoundException : Exception
    {
        string msg;
        public NoPizzaFoundException()
        {
            msg = "No Pizza with given ID found";
        }
        public override string Message => msg;
    }
}