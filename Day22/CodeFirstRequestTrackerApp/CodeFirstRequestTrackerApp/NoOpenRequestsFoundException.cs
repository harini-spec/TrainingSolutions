using System.Runtime.Serialization;

namespace CodeFirstRequestTrackerApp
{
    [Serializable]
    internal class NoOpenRequestsFoundException : Exception
    {
        public NoOpenRequestsFoundException()
        {
        }

        public NoOpenRequestsFoundException(string? message) : base(message)
        {
        }

        public NoOpenRequestsFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoOpenRequestsFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}