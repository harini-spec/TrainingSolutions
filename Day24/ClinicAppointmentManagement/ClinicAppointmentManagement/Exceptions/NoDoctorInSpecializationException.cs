using System.Runtime.Serialization;

namespace ClinicAppointmentManagement.Exceptions
{
    public class NoDoctorInSpecializationException : Exception
    {
        string msg;
        public NoDoctorInSpecializationException()
        {
            msg = "No doctors found in given specialization";
        }
        public override string Message => msg;
    }
}