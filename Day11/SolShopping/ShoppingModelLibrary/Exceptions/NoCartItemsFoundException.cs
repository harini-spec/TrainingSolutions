using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class NoCartItemsFoundException : Exception
    {
        string message;
        public NoCartItemsFoundException()
        {
            message = "Cart is empty - No cart items found";
        }
        public override string Message => message;
    }
}