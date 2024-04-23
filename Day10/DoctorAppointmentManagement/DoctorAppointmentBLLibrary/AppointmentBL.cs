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
        public int AddAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment CancelAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public Appointment ChangeDate(int id, DateTime newDate)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByAppointmentDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByDoctorName(string DoctorName)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByPatientName(string PatientName)
        {
            throw new NotImplementedException();
        }

        public Appointment UpdateStatus(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
