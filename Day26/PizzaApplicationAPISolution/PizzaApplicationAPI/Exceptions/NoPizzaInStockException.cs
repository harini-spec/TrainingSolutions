using System.Runtime.Serialization;

namespace PizzaApplicationAPI.Exceptions
{
    public class NoPizzaInStockException : Exception
    {
        string msg;
        public NoPizzaInStockException()
        {
            msg = "No pizza in stock";
        }
        public override string Message => msg;
    }
}