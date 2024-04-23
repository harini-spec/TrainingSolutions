using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public class PatientBL : IPatientService
    {
        public int AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Patient ChangePatientName(string OldPatientName, string NewPatientName)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetPatientAppointments(int id)
        {
            throw new NotImplementedException();
        }

        public Patient getPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientHistory(int id)
        {
            throw new NotImplementedException();
        }

        public Patient UpdatePatientHistory(int id, string PastAppointmentSummary)
        {
            throw new NotImplementedException();
        }
    }
}
