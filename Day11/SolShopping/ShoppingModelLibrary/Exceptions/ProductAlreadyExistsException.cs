using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class ProductAlreadyExistsException : Exception
    {
        string message;
        public ProductAlreadyExistsException()
        {
            message = "Product already exists!";
        }
        public override string Message => message;
    }
}