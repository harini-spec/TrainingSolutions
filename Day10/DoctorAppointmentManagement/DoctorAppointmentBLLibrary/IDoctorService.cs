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
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorByID(int id);
        Doctor GetDoctorByName(string name);
        Doctor GetDoctorBySpecialization(string specialization);
        List<Appointment> GetDoctorAppointments(int id);
        int GetDoctorCountInEachSpecialization();
        Doctor ChangeName(string DoctorOldName, string DoctorNewName);
        Doctor DeleteDoctorById(int id);
    }
}
