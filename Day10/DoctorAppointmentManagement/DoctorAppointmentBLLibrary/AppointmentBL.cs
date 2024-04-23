using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int, Appointment> _AppointmentRepository;
        public AppointmentBL()
        {
            _AppointmentRepository = new AppointmentRepository();
        }
        public int AddAppointment(Appointment appointment)
        {
            var result = _AppointmentRepository.Add(appointment);
            if (result != null)
            {
                return result.Id;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment CancelAppointment(int id)
        {
            Appointment appointment = _AppointmentRepository.Get(id);
            if (appointment != null)
            {
                _AppointmentRepository.Delete(id);
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment ChangeDate(int id, DateTime newDate)
        {
            Appointment appointment = _AppointmentRepository.Get(id);
            if (appointment != null)
            {
                appointment.AppointmentDate = newDate;
                _AppointmentRepository.Update(appointment);
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment GetAppointmentById(int id)
        {
            Appointment appointment = _AppointmentRepository.Get(id);
            if (appointment != null)
            {
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public List<Appointment> GetAppointmentsByAppointmentDate(DateTime date)
        {
            List<Appointment> appointments = _AppointmentRepository.GetAll();
            List<Appointment> result = new List<Appointment>();
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                    if (appointment.AppointmentDate == date)
                        result.Add(appointment);
                return result;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment UpdateStatus(int id, string status)
        {
            Appointment appointment = _AppointmentRepository.Get(id);
            if (appointment != null)
            {
                appointment.Status = status;
                _AppointmentRepository.Update(appointment);
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }
    }
}