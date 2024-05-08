using DoctorAppointmentModelLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IAppointmentService
    {
        int AddAppointment(Appointment appointment); // check patient and doctor availability
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAppointmentsByAppointmentDate(DateTime date);
        Appointment ChangeDate(int id, DateTime newDate);
        Appointment CancelAppointment(int id);

    }
}