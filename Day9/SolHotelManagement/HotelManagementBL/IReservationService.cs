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
        int AddReservation(Reservation reservation, List<Room> rooms);
        Reservation GetReservationByID(int ID);
        Reservation ModifyBooking(Reservation reservation, List<Room> rooms);
        Reservation CancelBooking(int ID);
        double CalculateCost(Reservation reservation, Room room);
        string AddCancellationPolicy();
    }
}
