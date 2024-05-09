using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;
        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        /// <summary>
        /// Automatically generates ID for Doctors 
        /// </summary>
        /// <returns>ID as int type</returns>
        public int GenerateId()
        {
            if (_doctors.Count() == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Checks if the value is already present. If not, creates a new entry in the Doctor Dictionary 
        /// </summary>
        /// <param name="item">Doctor Object</param>
        /// <returns>Inserted Doctor Object</returns>
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _doctors.Add(item.Id, item);
            return item;
        }

        /// <summary>
        /// Checks if the given ID is present. If found, deletes the Doctor record in the given ID 
        /// </summary>
        /// <param name="key">ID of the Doctor</param>
        /// <returns>Deleted Doctor data if present, else null</returns>
        public Doctor Delete(int key)
        {
            if(_doctors.ContainsKey(key))
            {
                Doctor doctor = _doctors[key];
                _doctors.Remove(key);
                return doctor;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Doctor record of given ID
        /// </summary>
        /// <param name="key">ID of the doctor</param>
        /// <returns>Doctor record if present, else null</returns>
        public Doctor Get(int key)
        {
            return _doctors[key] ?? null;
        }

        /// <summary>
        /// Gets all the Doctor records
        /// </summary>
        /// <returns>Doctor records as a List</returns>
        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null;
            return _doctors.Values.ToList();
        }

        /// <summary>
        /// Updates the existing doctor record 
        /// </summary>
        /// <param name="item">Doctor record</param>
        /// <returns>Updated Doctor record</returns>
        public Doctor Update(Doctor item)
        {
            if(_doctors.ContainsValue(item))
            {
                _doctors[item.Id] = item;
                return _doctors[item.Id];
            }
            return null;
        }
    }
}
