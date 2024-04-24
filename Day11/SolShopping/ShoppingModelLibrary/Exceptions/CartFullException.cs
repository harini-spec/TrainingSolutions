using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class CartFullException : Exception
    {
        string message;
        public CartFullException()
        {
            message = "Cart is full";
        }
        public override string Message => message;
    }
}