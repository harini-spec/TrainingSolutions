using ClinicAppointmentManagement.Exceptions;
using ClinicAppointmentManagement.Models;
using ClinicAppointmentManagement.Repositories;
using System.Numerics;

namespace ClinicAppointmentManagement.Services
{
    public class DoctorBL : IDoctorService
    {
        private readonly IRepository<int, Doctor> _DoctorRepository;
        public DoctorBL(IRepository<int, Doctor> repository)
        {
            _DoctorRepository = repository;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            try
            {
                var doctors = await _DoctorRepository.GetAll();
                return doctors.ToList();
            }
            catch (NoDoctorsFoundException)
            {
                throw new NoDoctorsFoundException();
            }
        }

        public async Task<Doctor> GetDoctorByID(int id)
        {
            try
            {
                Doctor doctor = await _DoctorRepository.GetById(id);
                return doctor;
            }
            catch(NoDoctorFoundException)
            {
                throw new NoDoctorFoundException();
            }
        }

        public async Task<List<Doctor>> GetDoctorBySpecialization(string specialization)
        {
            try
            {
                List<Doctor> result = new List<Doctor> ();
                var doctors = await _DoctorRepository.GetAll();
                foreach(var doctor in doctors)
                {
                    if(doctor.Specialization == specialization)
                        result.Add(doctor);
                }
                if (result.Count == 0)
                    throw new NoDoctorInSpecializationException();
                return result;
            }
            catch (NoDoctorInSpecializationException)
            {
                throw new NoDoctorInSpecializationException();
            }
            catch (NoDoctorsFoundException)
            {
                throw new NoDoctorsFoundException();
            }
        }

        public async Task<Doctor> UpdateDoctorExperience(int DoctorID, int experience)
        {
            try
            {
                Doctor doctor = await _DoctorRepository.GetById(DoctorID);
                doctor.Experience = experience;
                await _DoctorRepository.Update(doctor);
                return doctor;
            }
            catch (NoDoctorFoundException)
            {
                throw new NoDoctorFoundException();
            }
        }
    }
}
