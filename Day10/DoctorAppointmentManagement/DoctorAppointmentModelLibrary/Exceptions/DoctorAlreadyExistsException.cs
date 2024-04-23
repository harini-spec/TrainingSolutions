using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class DoctorAlreadyExistsException : Exception
    {
        string msg;
        public DoctorAlreadyExistsException()
        {
            msg = "Doctor Record already exists!";
        }
        public override string Message => msg;
    }
}