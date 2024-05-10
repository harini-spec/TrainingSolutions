using DoctorAppointmentModelLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly DoctorAppointmentContext context;
        // readonly Dictionary<int, Doctor> _doctors;
        public DoctorRepository()
        {
            context = new DoctorAppointmentContext();
            // _doctors = context.Doctors.ToDictionary(x => x.Id, x => x);
        }

        /// <summary>
        /// Checks if the value is already present. If not, creates a new entry in the Doctor Dictionary 
        /// </summary>
        /// <param name="item">Doctor Object</param>
        /// <returns>Inserted Doctor Object</returns>
        public Doctor Add(Doctor item)
        {
            if (context.Doctors.ToList().Contains(item))
            {
                return null;
            }
            context.Doctors.Add(item);
            context.SaveChanges();
            return item;
        }

        /// <summary>
        /// Checks if the given ID is present. If found, deletes the Doctor record in the given ID 
        /// </summary>
        /// <param name="key">ID of the Doctor</param>
        /// <returns>Deleted Doctor data if present, else null</returns>
        public Doctor Delete(int key)
        {
            List<Doctor> doctors = context.Doctors.ToList();
            Doctor doctor = doctors.SingleOrDefault(x => x.Id == key);
            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
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
            Doctor doctor = context.Doctors.Include(d => d.Appointments).SingleOrDefault(x => x.Id == key);
            if (doctor != null)
                return doctor;
            return null;
        }

        /// <summary>
        /// Gets all the Doctor records
        /// </summary>
        /// <returns>Doctor records as a List</returns>
        public List<Doctor> GetAll()
        {
            if (context.Doctors.Include(d => d.Appointments).ToList().Count == 0)
                return null;
            return context.Doctors.Include(d => d.Appointments).ToList();
        }

        /// <summary>
        /// Updates the existing doctor record 
        /// </summary>
        /// <param name="item">Doctor record</param>
        /// <returns>Updated Doctor record</returns>
        public Doctor Update(Doctor item)
        {
            List<Doctor> doctors = context.Doctors.ToList();
            Doctor doctor = doctors.SingleOrDefault(x => x.Id == item.Id);
            if (doctor != null)
            {
                doctor = item;
                context.Doctors.Update(doctor);
                context.SaveChanges();
                return doctor;
            }
            return null;
        }
    }
}