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
        int AddReservation(Reservation reservation, int roomID);
        Reservation GetReservationByID(int ID);
        Reservation ModifyBooking(Reservation reservation);
        Reservation CancelBooking(int ID);
        double CalculateCost(Reservation reservation, int RoomID);
        string AddCancellationPolicy();
    }
}
