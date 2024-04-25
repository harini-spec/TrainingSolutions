using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class CartItemAlreadyExistsException : Exception
    {
        string message;
        public CartItemAlreadyExistsException()
        {
            message = "Cart Item already exists";
        }
        public override string Message => message;
    }
}