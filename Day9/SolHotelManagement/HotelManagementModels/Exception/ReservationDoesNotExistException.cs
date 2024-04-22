using System.Runtime.Serialization;

namespace HotelManagementBL
{
    public class ReservationDoesNotExistException : Exception
    {
        string msg;
        public ReservationDoesNotExistException()
        {
            msg = "Reservation does not exist for the given ID";
        }
        public override string Message => msg;
    }
}