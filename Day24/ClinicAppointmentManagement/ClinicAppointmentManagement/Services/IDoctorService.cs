using ClinicAppointmentManagement.Models;

namespace ClinicAppointmentManagement.Services
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorByID(int id);
        Task<List<Doctor>> GetDoctorBySpecialization(string specialization); 
        Task<Doctor> UpdateDoctorExperience(int DoctorID, int experience);
    }
}
