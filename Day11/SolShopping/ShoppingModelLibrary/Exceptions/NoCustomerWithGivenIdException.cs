using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGivenIdException : Exception
    {
        string message;
        public NoCustomerWithGivenIdException()
        {
            message = "Customer with the given Id is not present";
        }
        public override string Message => message;
    }
}
