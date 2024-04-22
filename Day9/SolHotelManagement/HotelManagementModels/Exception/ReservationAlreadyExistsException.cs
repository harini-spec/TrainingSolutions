using System.Runtime.Serialization;

namespace HotelManagementBL
{
    public class ReservationAlreadyExistsException : Exception
    {
        string msg;
        public ReservationAlreadyExistsException()
        {
            msg = "Reservation already exists";
        }
        public override string Message => msg;
    }
}