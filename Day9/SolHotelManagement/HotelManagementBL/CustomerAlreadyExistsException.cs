namespace HotelManagementBL
{
    public class CustomerAlreadyExistsException : Exception
    {
        string msg;
        public CustomerAlreadyExistsException()
        {
            msg = "Customer profile already exists";
        }
        public override string Message => msg;
    }
}