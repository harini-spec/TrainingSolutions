using ClinicAppointmentManagement.Contexts;
using ClinicAppointmentManagement.Exceptions;
using ClinicAppointmentManagement.Models;

namespace ClinicAppointmentManagement.Repositories
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly ClinicContext _context;
        public PatientRepository(ClinicContext context) 
        {
            _context = context;
        }

        public async Task<Patient> Add(Patient item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Patient> DeleteById(int key)
        {
            try
            {
                var patient = await GetById(key);
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return patient;
            }
            catch(NoPatientFoundException)
            {
                throw new NoPatientFoundException();
            }
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            var patients = _context.Patients;
            if (patients == null)
                throw new NoPatientsFoundException();
            return patients;
        }

        public async Task<Patient> GetById(int key)
        {
            try
            {
                var patient = _context.Patients.FirstOrDefault(d => d.Id == key);
                return patient;
            }
            catch(NoPatientFoundException)
            {
                throw new NoPatientFoundException();
            }
            
        }

        public async Task<Patient> Update(Patient item)
        {
            try
            {
                var patient = await GetById(item.Id);
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch(NoPatientFoundException)
            {
                throw new NoPatientFoundException();
            }
        }
    }
}
