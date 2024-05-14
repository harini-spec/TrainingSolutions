using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoAppointmentFoundException : Exception
    {
        string msg;
        public NoAppointmentFoundException()
        {
            msg = "No appointment with given id is found";
        }
        public override string Message => msg;
    }
}