using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class PatientDoesNotExistException : Exception
    {
        string msg;
        public PatientDoesNotExistException()
        {
            msg = "Patient Record does not exist";
        }
        public override string Message => msg;
    }
}