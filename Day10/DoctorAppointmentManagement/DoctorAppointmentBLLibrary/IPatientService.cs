using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IPatientService
    {
        int AddPatient(Patient patient);
        Patient getPatientById(int id);
        Patient ChangePatientName(int PatientId, string NewPatientName);
        List<int> GetPatientAppointments(int id);

    }
}
