using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class AppointmentNotFoundException : Exception
    {
        string msg;
        public AppointmentNotFoundException()
        {
            msg = "Appointment is not found";
        }
        public override string Message => msg;
    }
}