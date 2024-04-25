using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class NotEnoughStockException : Exception
    {
        string message;
        public NotEnoughStockException()
        {
            message = "Not enough products present in the storage unit";
        }
        public override string Message => message;
    }
}