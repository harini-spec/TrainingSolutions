using System.Collections;
using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class NoRecordsFoundException : Exception
    {
        string message;
        public NoRecordsFoundException()
        {
            message = "No records Found";
        }
        public override string Message => message;

    }
}