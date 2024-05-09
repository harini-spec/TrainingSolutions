using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class NullDataException : Exception
    {
        string message;
        public NullDataException()
        {
            message = "No data provided";
        }
        public override string Message => message;
    }
}