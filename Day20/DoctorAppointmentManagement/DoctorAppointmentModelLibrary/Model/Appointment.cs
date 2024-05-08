using System;
using System.Collections.Generic;

namespace DoctorAppointmentModelLibrary.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int? Doctor { get; set; }
        public int? Patient { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Status { get; set; }

        public virtual Doctor? DoctorNavigation { get; set; }
        public virtual Patient? PatientNavigation { get; set; }

        public Appointment(int? doctor, int? patient, DateTime? appointmentDate, string? status)
        {
            Doctor = doctor;
            Patient = patient;
            AppointmentDate = appointmentDate;
            Status = status;
        }

        public override bool Equals(object? obj)
        {
            Appointment appointment = obj as Appointment;
            if (this.Patient.Equals(appointment.Patient) && this.Doctor.Equals(appointment.Doctor) && this.AppointmentDate.Equals(appointment.AppointmentDate))
                return true;
            return false;
        }
    }
}
