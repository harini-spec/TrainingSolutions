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
        public RoomBL()
        {
            _RoomRepository = new RoomRepository();
        }

        public int AddRoom(Room room)
        {
            var result = _RoomRepository.Add(room);
            if (result != null)
                return result.Id;
            throw new RoomAlreadyExistsException();
        }

        public bool CheckRoomAvailability(int RoomID)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomByID(int RoomID)
        {
            return _RoomRepository.Get(RoomID);
        }
    }
}
