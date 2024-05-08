using DoctorAppointmentModelLibrary.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly DoctorAppointmentContext context;
        public AppointmentRepository()
        {
            context = new DoctorAppointmentContext();
        }

        /// <summary>
        /// Checks if the value is already present. If not, creates a new entry in the Appointment Dictionary 
        /// </summary>
        /// <param name="item">Appointment Object</param>
        /// <returns>Inserted Appointment Object</returns>
        public Appointment Add(Appointment item)
        {
            if (context.Appointments.ToList().Contains(item))
            {
                return null;
            }
            context.Appointments.Add(item);
            context.SaveChanges();
            return item;
        }

        /// <summary>
        /// Checks if the given ID is present. If found, deletes the Appointment record in the given ID 
        /// </summary>
        /// <param name="key">ID of the Appointment</param>
        /// <returns>Deleted Appointment data if present, else null</returns>
        public Appointment Delete(int key)
        {
            List<Appointment> Appointments = context.Appointments.ToList();
            Appointment appointment = Appointments.SingleOrDefault(x => x.Id == key);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                context.SaveChanges();
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
            List<Appointment> appointments = context.Appointments.ToList();
            Appointment appointment = appointments.SingleOrDefault(x => x.Id == key);
            if (appointment != null)
                return appointment;
            return null;
        }

        /// <summary>
        /// Gets all the Appointment records
        /// </summary>
        /// <returns>Appointment records as a List</returns>
        public List<Appointment> GetAll()
        {
            if (context.Appointments.ToList().Count == 0)
                return null;
            return context.Appointments.ToList();
        }

        /// <summary>
        /// Updates the existing Appointment record 
        /// </summary>
        /// <param name="item">Appointment record</param>
        /// <returns>Updated Appointment record</returns>
        public Appointment Update(Appointment item)
        {
            List<Appointment> appointments = context.Appointments.ToList();
            Appointment appointment = appointments.SingleOrDefault(x => x.Id == item.Id);
            if (appointment != null)
            {
                appointment = item;
                context.Appointments.Update(appointment);
                context.SaveChanges();
                return appointment;
            }
            return null;
        }

    }
}
