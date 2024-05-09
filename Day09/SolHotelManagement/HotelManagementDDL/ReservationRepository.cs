using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDAL
{
    public class ReservationRepository : IRepository<int, Reservation>
    {
        readonly Dictionary<int, Reservation> _reservations;

        public ReservationRepository()
        {
            _reservations = new Dictionary<int, Reservation>();
        }

        public int GenerateId()
        {
            if (_reservations.Count == 0)
                return 1;
            int id = _reservations.Keys.Max();
            return ++id;
        }

        public Reservation Add(Reservation item)
        {
            if (_reservations.ContainsValue(item))
                return null;
            int Id = GenerateId();
            item.Id = Id;
            _reservations.Add(Id, item);
            return _reservations[Id];
        }

        public Reservation Delete(int key)
        {
            if (_reservations.ContainsKey(key))
            {
                var Reservation = _reservations[key];
                _reservations.Remove(key);
                return Reservation;
            }
            return null;
        }

        public Reservation Get(int key)
        {
            return _reservations.ContainsKey(key) ? _reservations[key] : null;
        }

        public List<Reservation> GetAll()
        {
            if (_reservations.Count == 0)
                return null;
            return _reservations.Values.ToList();
        }

        public Reservation Update(Reservation item)
        {
            if (_reservations.ContainsKey(item.Id))
            {
                _reservations[item.Id] = item;
                return _reservations[item.Id];
            }
            return null;
        }
    }
}
