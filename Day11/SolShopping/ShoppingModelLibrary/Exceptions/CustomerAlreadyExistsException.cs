using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class CustomerAlreadyExistsException : Exception
    {
        string message;
        public CustomerAlreadyExistsException()
        {
            message = "Customer already exists!";
        }
        public override string Message => message;
    }
}