using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBL
{
    public interface IReservationService
    {
        List<Reservation> GetReservations(int CustomerID);
        int AddReservation(Reservation reservation);
        Reservation GetReservationByID(int ID);
        Reservation ModifyBooking(Reservation reservation);
        Reservation CancelBooking(int ID);
    }
}
