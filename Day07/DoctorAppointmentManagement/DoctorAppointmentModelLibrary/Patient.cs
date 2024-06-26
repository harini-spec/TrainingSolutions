﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLibrary
{
    public class Patient
    {
        List<Appointment> Appointments;
        List<Doctor> Doctors;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string History { get; set; }

        public Patient()
        {
            Appointments = new List<Appointment>();
            Doctors = new List<Doctor>();
            Id = 0;
            Name = string.Empty;
            Age = 0;    
            Gender = string.Empty;
            History = string.Empty;
        }

        public Patient(Doctor doctor, List<Appointment> appointments, List<Doctor> doctors, int id, string name, int age, string gender, string history)
        {
            this.Appointments = appointments;
            this.Doctors = doctors;
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            History = history;
        }

        /// <summary>
        /// Checks if 2 Patient objects are same by comparing their names and history 
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True if they are same, else false</returns>
        public override bool Equals(object? obj)
        {
            Patient patient = obj as Patient;
            if(this.Name.Equals(patient.Name) && this.History.Equals(patient.History))
                return true;
            return false;
        }

        /// <summary>
        /// returns the properties of the patient
        /// </summary>
        /// <returns>Properties as string</returns>
        public override string ToString()
        {
            return Name + " " + Age + " " + Gender + " " + History;
        }
    }
}
