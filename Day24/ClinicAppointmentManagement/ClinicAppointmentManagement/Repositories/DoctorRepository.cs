using ClinicAppointmentManagement.Contexts;
using ClinicAppointmentManagement.Exceptions;
using ClinicAppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentManagement.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> DeleteById(int key)
        {
            try
            {
                var doctor = await GetById(key);
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                return doctor;
            }
            catch (NoDoctorFoundException)
            {
                throw new NoDoctorFoundException();
            }
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            if (doctors.Count == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> GetById(int key)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == key);
            if(doctor == null)
                throw new NoDoctorFoundException();
            return doctor;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            try
            {
                var doctor = await GetById(item.Id);
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (NoDoctorFoundException)
            {
                throw new NoDoctorFoundException();
            }
        }
    }
}
