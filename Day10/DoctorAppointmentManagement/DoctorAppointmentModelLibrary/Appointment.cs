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
        Doctor doctor;

        Patient patient;
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        string Status;
        public Appointment() 
        { 
            doctor = new Doctor();
            patient = new Patient();
            Id = 0;
            AppointmentDate = new DateTime();
            Status = string.Empty;
        }

        public Appointment(int id, DateTime appointmentDate, Doctor doctor, Patient patient, string status)
        {
            Id = id;
            AppointmentDate = appointmentDate;
            this.doctor = doctor;
            this.patient = patient;
            Status = status;
        }

        /// <summary>
        /// Checks if 2 Appointment objects are same by comparing the patient names and appointment date
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True if they are same, else false</returns>
        public override bool Equals(object? obj)
        {
            Appointment appointment = obj as Appointment;
            if(this.patient.Name.Equals(appointment.patient.Name) && this.AppointmentDate.Equals(appointment.AppointmentDate))
                return true;
            return false;
        }

        /// <summary>
        /// returns the properties of the appointment
        /// </summary>
        /// <returns>Properties as string</returns>
        public override string ToString()
        {
            return patient.Name + " " + doctor.Name + " " + AppointmentDate + " " + Status;
        }
    }
}
