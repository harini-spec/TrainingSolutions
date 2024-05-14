using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoDoctorFoundException : Exception
    {
        string msg;
        public NoDoctorFoundException()
        {
            msg = "Doctor not found";
        }
        public override string Message => msg;
    }
}