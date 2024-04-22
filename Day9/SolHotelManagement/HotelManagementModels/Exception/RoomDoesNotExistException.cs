using System.Runtime.Serialization;

namespace HotelManagementBL
{
    public class RoomDoesNotExistException : Exception
    {
        string msg;
        public RoomDoesNotExistException()
        {
            msg = "Room does not exist";
        }
        public override string Message => msg;
    }
}