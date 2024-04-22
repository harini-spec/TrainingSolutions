using HotelManagementDAL;
using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBL
{
    public class RoomBL : IRoomService
    {
        readonly IRepository<int, Room> _RoomRepository;
        readonly IRepository<int, Reservation> _ReservationRepository;

        public RoomBL()
        {
            _RoomRepository = new RoomRepository();
            _ReservationRepository = new ReservationRepository();
        }

        public int AddRoom(Room room)
        {
            var result = _RoomRepository.Add(room);
            if (result != null)
                return result.Id;
            throw new RoomAlreadyExistsException();
        }

        public bool CheckRoomAvailability(DateTime checkin, DateTime checkout, int RoomID)
        {
           Room room = _RoomRepository.Get(RoomID);
            List<int> reservations = room.Reservations;
            foreach (int reservation in reservations)
            {
                Reservation ExisitingReservation = _ReservationRepository.Get(reservation);
                if(ExisitingReservation == null) 
                {
                    return true;
                }
                if (ExisitingReservation.CheckInDate == checkin || ExisitingReservation.CheckOutDate == checkout 
                    || (checkin > ExisitingReservation.CheckInDate && checkin < ExisitingReservation.CheckOutDate) 
                    || (checkout > ExisitingReservation.CheckInDate && checkout < ExisitingReservation.CheckOutDate)
                    || (checkin <  ExisitingReservation.CheckInDate && checkout > ExisitingReservation.CheckOutDate))
                {
                    return false;
                }
            }
            return true;
        }

        public Room GetRoomByID(int RoomID)
        {
            if(_RoomRepository.Get(RoomID)!=null)
                return _RoomRepository.Get(RoomID);
            throw new RoomDoesNotExistException();
        }

        public List<Room> GetAllRooms()
        {
            return _RoomRepository.GetAll();
        }

        public void AddReservation(int id)
        {
            Room room = GetRoomByID(id);
            room.Reservations.Add(id);
            _RoomRepository.Update(room);
        }
    }
}
