namespace HotelManagementBL
{
    public class RoomAlreadyExistsException : Exception
    {
        string msg;
        public RoomAlreadyExistsException() 
        {
            msg = "Room already exists";
        }
        public override string Message => msg;
    }
}