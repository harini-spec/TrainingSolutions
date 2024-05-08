using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary.Model;

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
                if (DoctorsInSpecialization.Count > 0)
                    return DoctorsInSpecialization;
                else
                    throw new DoctorDoesNotExistException();
            }
            throw new NoDoctorRecordsFoundException();
        }

        public HashSet<Appointment> GetDoctorAppointments(int DoctorId)
        {
            Doctor doctor = _DoctorRepository.Get(DoctorId);
            if (doctor != null)
                if (doctor.Appointments.Count > 0)
                    return doctor.Appointments;
                else
                    throw new NoAppointmentsFoundException();
            throw new DoctorDoesNotExistException();
        }

    }
}
