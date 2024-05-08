using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class AppointmentAlreadyExistsException : Exception
    {
        public string msg;
        public AppointmentAlreadyExistsException()
        {
            msg = "Appointment already exists!";
        }

        public override string Message => msg;
    }
}