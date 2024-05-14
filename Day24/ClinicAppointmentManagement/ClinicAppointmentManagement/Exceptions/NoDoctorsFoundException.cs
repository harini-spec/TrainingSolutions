using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoDoctorsFoundException : Exception
    {
        string msg;
        public NoDoctorsFoundException()
        {
            msg = "No doctor records found";
        }
        public override string Message => msg;
    }
}