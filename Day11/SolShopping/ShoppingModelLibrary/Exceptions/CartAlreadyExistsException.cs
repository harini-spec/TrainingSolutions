using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class CartAlreadyExistsException : Exception
    {
        string message;
        public CartAlreadyExistsException()
        {
            message = "Cart already exists";
        }
        public override string Message => message;
    }
}