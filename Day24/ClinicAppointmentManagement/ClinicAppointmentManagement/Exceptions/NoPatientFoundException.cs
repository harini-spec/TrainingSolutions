using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoPatientFoundException : Exception
    {
        string msg;
        public NoPatientFoundException()
        {
            msg = "No patient with given ID found";
        }
        public override string Message => msg;
    }
}