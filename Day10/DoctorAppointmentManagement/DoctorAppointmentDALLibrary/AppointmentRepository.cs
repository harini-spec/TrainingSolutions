using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;
        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        /// <summary>
        /// Automatically generates ID for Appointments 
        /// </summary>
        /// <returns>ID as int type</returns>
        public int GenerateId()
        {
            if (_appointments.Count() == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Checks if the value is already present. If not, creates a new entry in the Appointment Dictionary 
        /// </summary>
        /// <param name="item">Appointment Object</param>
        /// <returns>Inserted Appointment Object</returns>
        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _appointments.Add(item.Id, item);
            return item;
        }

        /// <summary>
        /// Checks if the given ID is present. If found, deletes the Appointment record in the given ID 
        /// </summary>
        /// <param name="key">ID of the Appointment</param>
        /// <returns>Deleted Appointment data if present, else null</returns>
        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                Appointment appointment = _appointments[key];
                _appointments.Remove(key);
                return appointment;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Appointment record of given ID
        /// </summary>
        /// <param name="key">ID of the Appointment</param>
        /// <returns>Appointment record if present, else null</returns>
        public Appointment Get(int key)
        {
            if( _appointments.ContainsKey(key))
                return _appointments[key];
            return null;
        }

        /// <summary>
        /// Gets all the Appointment records
        /// </summary>
        /// <returns>Appointment records as a List</returns>
        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }

        /// <summary>
        /// Updates the existing Appointment record 
        /// </summary>
        /// <param name="item">Appointment record</param>
        /// <returns>Updated Appointment record</returns>
        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                _appointments[item.Id] = item;
                return _appointments[item.Id];
            }
            return null;
        }

    }
}
