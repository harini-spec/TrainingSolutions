namespace ClinicAppointmentManagement.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsDone { get; set; } = false;

        public int doctorId;
        public Doctor AppointedDoctor { get; set; }

        public int patientId;
        public Patient AppointmentForPatient { get; set; }
    }
}
