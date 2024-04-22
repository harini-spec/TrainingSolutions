using HotelManagementDAL;
using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBL
{
    public class ReservationBL : IReservationService
    {
        readonly IRepository<int, Reservation> _ReservationRepository;
        readonly IRepository<int, Room> _RoomRepository;
        public ReservationBL()
        {
            _ReservationRepository = new ReservationRepository();
            _RoomRepository = new RoomRepository();
        }

        public int AddReservation(Reservation reservation, List<Room> rooms)
        {
            Room room = new Room();
            for(int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Id == reservation.Room)
                    room = rooms[i];
            }
            reservation.TotalCost = CalculateCost(reservation, room);
            reservation.CancellationPolicy = AddCancellationPolicy();
            var result = _ReservationRepository.Add(reservation);
            if (result != null)
                return result.Id;
            throw new ReservationAlreadyExistsException();
        }

        public string AddCancellationPolicy()
        {
            return "80% refund if you cancel the reservation within 24 hours. If not, no refund will be given";
        }

        public double CalculateCost(Reservation reservation, Room room)
        {
            int days = (reservation.CheckOutDate - reservation.CheckInDate).Days;
            return days * room.NightlyRate;
        }

        public Reservation CancelBooking(int ID)
        {
            Reservation reservation = GetReservationByID(ID);
            if (reservation != null)
            {
                return _ReservationRepository.Delete(ID);
            }
            throw new ReservationDoesNotExistException();
        }

        public Reservation GetReservationByID(int ID)
        {
            return _ReservationRepository.Get(ID);
        }

        public Reservation ModifyBooking(Reservation reservation, List<Room> rooms)
        {
            Room room = new Room();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Id == reservation.Room)
                    room = rooms[i];
            }
            reservation.TotalCost = CalculateCost(reservation, room);
            return _ReservationRepository.Update(reservation);
        }
    }
}
