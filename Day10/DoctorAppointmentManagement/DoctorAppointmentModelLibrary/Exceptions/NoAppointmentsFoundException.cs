namespace DoctorAppointmentBLLibrary
{
    public class NoAppointmentsFoundException : Exception
    {
        string msg;
        public NoAppointmentsFoundException()
        {
            msg = "No appointments were found";
        }

        public override string Message => msg;
    }
}