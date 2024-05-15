using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoPizzasFoundException : Exception
    {
        string msg;
        public NoPizzasFoundException()
        {
            msg = "No pizzas were found";
        }
        public override string Message => msg;
    }
}