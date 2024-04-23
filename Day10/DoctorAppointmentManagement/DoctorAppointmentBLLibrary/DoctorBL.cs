using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _DoctorRepository;

        public DoctorBL(IRepository<int, Doctor> _doctorRepository)
        {
            _DoctorRepository = _doctorRepository;
        }

        public int AddDoctor(Doctor doctor)
        {
            var result = _DoctorRepository.Add(doctor);
            if (result != null)
            {
                return result.Id;
            }
            throw new DoctorAlreadyExistsException();
        }

        public Doctor ChangeName(int DoctorID, string DoctorNewName)
        {
            Doctor doctor = _DoctorRepository.Get(DoctorID);
            if (doctor != null)
            {
                doctor.Name = DoctorNewName;
                return (_DoctorRepository.Update(doctor));
            }
            throw new DoctorDoesNotExistException();
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _DoctorRepository.GetAll();
            if (doctors != null)
                return doctors;
            throw new NoDoctorRecordsFoundException();
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor doctor = _DoctorRepository.Get(id);
            if (doctor != null)
                return _DoctorRepository.Delete(id);
            throw new DoctorDoesNotExistException();
        }

        public List<int> GetDoctorAppointments(int DoctorId)
        {
            Doctor doctor = _DoctorRepository.Get(DoctorId);
            if (doctor != null)
                if (doctor.Appointments == null)
                    throw new NoAppointmentsFoundException();
                else
                    return doctor.Appointments;
            throw new DoctorDoesNotExistException();
        }

        public Doctor GetDoctorByID(int id)
        {
            Doctor doctor = _DoctorRepository.Get(id);
            if (doctor != null)
                return doctor;
            throw new DoctorDoesNotExistException();
        }

        public List<Doctor> GetDoctorBySpecialization(string specialization)
        {
            List<Doctor> doctors = _DoctorRepository.GetAll();
            List<Doctor> DoctorsInSpecialization = new List<Doctor>();
            if (doctors != null)
            {
                foreach (var doctor in doctors)
                {
                    if (doctor.Specialization == specialization)
                        DoctorsInSpecialization.Add(doctor);
                }
                return DoctorsInSpecialization;
            }
            throw new NoDoctorRecordsFoundException();
        }
    }
}