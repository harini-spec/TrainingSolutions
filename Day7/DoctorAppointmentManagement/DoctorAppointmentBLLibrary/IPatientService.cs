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
        Patient getPatientByName(string PatientName);
        Patient ChangePatientName(string OldPatientName, string NewPatientName);
        Patient UpdatePatientHistory(int id, string PastAppointmentSummary);
        List<Appointment> GetPatientAppointments(int id);
        Patient GetPatientHistory(int id);
        Patient DeletePatientById(int id);

    }
}
