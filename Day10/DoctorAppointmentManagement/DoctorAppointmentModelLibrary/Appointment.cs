using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorAppointmentModelLibrary
{
    public class Appointment
    {
        public int doctorId;

        public int patientId;
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment()
        {
            doctorId = 0;
            patientId = 0;
            Id = 0;
            AppointmentDate = new DateTime();
        }

        public Appointment(int id, DateTime appointmentDate, int doctor, int patient)
        {
            Id = id;
            AppointmentDate = appointmentDate;
            this.doctorId = doctor;
            this.patientId = patient;
        }

        /// <summary>
        /// Checks if 2 Appointment objects are same by comparing the patient names and appointment date
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True if they are same, else false</returns>
        public override bool Equals(object? obj)
        {
            Appointment appointment = obj as Appointment;
            if (this.patientId.Equals(appointment.patientId) && this.doctorId.Equals(appointment.doctorId) && this.AppointmentDate.Equals(appointment.AppointmentDate))
                return true;
            return false;
        }

        /// <summary>
        /// returns the properties of the appointment
        /// </summary>
        /// <returns>Properties as string</returns>
        public override string ToString()
        {
            return patientId + " " + doctorId + " " + AppointmentDate;
        }
    }
}
