using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class PatientAlreadyExistsException : Exception
    {
        string msg;
        public PatientAlreadyExistsException()
        {
            msg = "Patient Record already exists";
        }
        public override string Message => msg;
    }
}