using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary
{
    public class NoDoctorRecordsFoundException : Exception
    {
        string msg;
        public NoDoctorRecordsFoundException()
        {
            msg = "No doctor records found!";
        }
        public override string Message => msg;
    }
}