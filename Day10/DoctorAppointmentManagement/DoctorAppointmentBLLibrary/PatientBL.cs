using DoctorAppointmentDALLibrary;
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
        readonly IRepository<int, Patient> _PatientRepository;

        public PatientBL()
        {
            _PatientRepository = new PatientRepository();
        }
        public int AddPatient(Patient patient)
        {
            var result = _PatientRepository.Add(patient);
            if (result != null)
                return result.Id;
            throw new PatientAlreadyExistsException();
        }

        public Patient ChangePatientName(int PatientId, string NewPatientName)
        {
            Patient patient = _PatientRepository.Get(PatientId);
            if (patient != null)
            {
                patient.Name = NewPatientName;
                return (_PatientRepository.Update(patient));
            }
            throw new PatientDoesNotExistException();
        }

        public List<Appointment> GetPatientAppointments(int id)
        {
            Patient patient = _PatientRepository.Get(id);
            if (patient != null)
                return patient.Appointments;
            throw new PatientDoesNotExistException();
        }

        public Patient getPatientById(int id)
        {
            Patient patient = _PatientRepository.Get(id);
            if (patient != null)
                return patient;
            throw new PatientDoesNotExistException();
        }
    }
}