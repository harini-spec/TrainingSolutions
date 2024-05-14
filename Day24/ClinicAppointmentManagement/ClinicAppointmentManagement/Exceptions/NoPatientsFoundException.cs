using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoPatientsFoundException : Exception
    {
        string msg;
        public NoPatientsFoundException()
        {
            msg = "No patient records found";
        }
        public override string Message => msg;
    }
}