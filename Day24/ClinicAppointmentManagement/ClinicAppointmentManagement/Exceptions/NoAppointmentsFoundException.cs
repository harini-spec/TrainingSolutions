using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoAppointmentsFoundException : Exception
    {
        string msg;
        public NoAppointmentsFoundException()
        {
            msg = "No appointments found";
        }
        public override string Message => msg;
    }
}