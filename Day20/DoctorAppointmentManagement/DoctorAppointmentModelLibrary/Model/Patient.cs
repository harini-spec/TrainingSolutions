using System;
using System.Collections.Generic;

namespace DoctorAppointmentModelLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public virtual HashSet<Appointment> Appointments { get; set; }
        public Patient(string name, int age, string gender, HashSet<Appointment> appointments)
        {
            this.Appointments = appointments;
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override bool Equals(object? obj)
        {
            Patient patient = obj as Patient;
            if (this.Name.Equals(patient.Name) && this.Age.Equals(patient.Age) && this.Gender.Equals(patient.Gender))
                return true;
            return false;
        }
    }
}
