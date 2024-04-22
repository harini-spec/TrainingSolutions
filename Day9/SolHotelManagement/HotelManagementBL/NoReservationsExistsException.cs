using System.Runtime.Serialization;

namespace HotelManagementBL
{
    public class NoReservationsExistsException : Exception
    {
        string msg;
        public NoReservationsExistsException()
        {
            msg = "No such reservation present";
        }
    }
}