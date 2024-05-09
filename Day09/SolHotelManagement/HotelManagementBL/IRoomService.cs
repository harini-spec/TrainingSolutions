using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBL
{
    public interface IRoomService
    {
        int AddRoom(Room room);
        bool CheckRoomAvailability(DateTime checkin, DateTime checkout, int RoomID, List<Room> rooms);
        Room GetRoomByID(int RoomID);
        List<Room> GetAllRooms();
        void AddReservation(int id);
    }
}
