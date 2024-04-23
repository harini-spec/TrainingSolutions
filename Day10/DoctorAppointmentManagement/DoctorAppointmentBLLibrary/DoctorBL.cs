using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public class DoctorBL : IDoctorService
    {
        public int AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor ChangeName(string DoctorOldName, string DoctorNewName)
        {
            throw new NotImplementedException();
        }

        public Doctor DeleteDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetDoctorAppointments(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorByID(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorByName(string name)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorBySpecialization(string specialization)
        {
            throw new NotImplementedException();
        }

        public int GetDoctorCountInEachSpecialization()
        {
            throw new NotImplementedException();
        }
    }
}
