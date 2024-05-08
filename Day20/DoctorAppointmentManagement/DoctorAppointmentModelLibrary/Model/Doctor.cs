using System;
using System.Collections.Generic;

namespace DoctorAppointmentModelLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public Doctor(string? name, int? age, string? specialization, string? qualification, int? experience, HashSet<Appointment> appointments)
        {
            Name = name;
            Age = age;
            Specialization = specialization;
            Qualification = qualification;
            Experience = experience;
            Appointments = appointments;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Specialization { get; set; }
        public string? Qualification { get; set; }
        public int? Experience { get; set; }

        public virtual HashSet<Appointment> Appointments { get; set; }

        public override bool Equals(object? obj)
        {
            Doctor doctor = obj as Doctor;
            if (doctor.Name == this.Name && doctor.Age == this.Age && doctor.Qualification == this.Qualification && doctor.Experience == this.Experience && doctor.Specialization == this.Specialization)
                return true;
            return false;
        }
    }
}
