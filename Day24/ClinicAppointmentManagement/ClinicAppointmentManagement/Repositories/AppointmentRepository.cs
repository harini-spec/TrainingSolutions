using ClinicAppointmentManagement.Contexts;
using ClinicAppointmentManagement.Exceptions;
using ClinicAppointmentManagement.Models;

namespace ClinicAppointmentManagement.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly ClinicContext _context;

        public AppointmentRepository(ClinicContext context)
        {
            _context = context;
        }
        public async Task<Appointment> Add(Appointment item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Appointment> DeleteById(int key)
        {
            try
            {
                var appointment = await GetById(key);
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
                return appointment;
            }
            catch (NoAppointmentFoundException)
            {
                throw new NoAppointmentFoundException();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            var appointments = _context.Appointments;
            if (appointments == null)
                throw new NoAppointmentsFoundException();
            return appointments;
        }

        public async Task<Appointment> GetById(int key)
        {
            var appointment = _context.Appointments.FirstOrDefault(d => d.Id == key);
            if (appointment == null)
                throw new NoAppointmentFoundException();
            return appointment;
        }

        public async Task<Appointment> Update(Appointment item)
        {
            try
            {
                var appointment = await GetById(item.Id);
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (NoAppointmentFoundException)
            {
                throw new NoAppointmentFoundException();
            }
        }
    }
}
