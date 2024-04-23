using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class DoctorDoesNotExistException : Exception
    {
        string msg;
        public DoctorDoesNotExistException()
        {
            msg = "Doctor Record does not exist!";
        }
        public override string Message => msg;
    }
}