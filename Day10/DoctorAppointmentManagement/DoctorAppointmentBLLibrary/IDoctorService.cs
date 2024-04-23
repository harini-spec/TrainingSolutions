using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentModelLibrary;

namespace DoctorAppointmentBLLibrary
{
    public interface IDoctorService
    {
        Doctor DeleteDoctor(int id);
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorByID(int id);
        List<Doctor> GetDoctorBySpecialization(string specialization); // shd check for 0 doctors in specialization in frontend
        List<int> GetDoctorAppointments(int id); // shd check for 0 appointments in frontend
        Doctor ChangeName(int DoctorID, string DoctorNewName);
        List<Doctor> GetAllDoctors();
    }
}