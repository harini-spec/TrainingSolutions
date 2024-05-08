using DoctorAppointmentModelLibrary.Model;

namespace DoctorAppointmentBLLibrary
{
    public interface IDoctorService
    {
        Doctor DeleteDoctor(int id); // delete all of their appointments 
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorByID(int id);
        List<Doctor> GetDoctorBySpecialization(string specialization); // shd check for 0 doctors in specialization in frontend
        Doctor ChangeName(int DoctorID, string DoctorNewName);
        List<Doctor> GetAllDoctors();
        public HashSet<Appointment> GetDoctorAppointments(int DoctorId);
    }
}