using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDAL
{
    public class RoomRepository : IRepository<int, Room>
    {
        readonly Dictionary<int, Room> _rooms;

        public RoomRepository()
        {
            _rooms = new Dictionary<int, Room>();
        }

        public int GenerateId()
        {
            int id = _rooms.Keys.Max();
            return ++id;
        }
        public Room Add(Room item)
        {
            if (_rooms.ContainsValue(item))
                return null;
            int Id = GenerateId();
            item.Id = Id;
            _rooms.Add(Id, item);
            return _rooms[Id];
        }

        public Room Delete(int key)
        {
            if (_rooms.ContainsKey(key))
            {
                var Room = _rooms[key];
                _rooms.Remove(key);
                return Room;
            }
            return null;
        }

        public Room Get(int key)
        {
            return _rooms.ContainsKey(key) ? _rooms[key] : null;
        }

        public List<Room> GetAll()
        {
            if (_rooms.Count == 0)
                return null;
            return _rooms.Values.ToList();
        }

        public Room Update(Room item)
        {
            if (_rooms.ContainsKey(item.Id))
            {
                _rooms[item.Id] = item;
                return _rooms[item.Id];
            }
            return null;
        }
    }
}
