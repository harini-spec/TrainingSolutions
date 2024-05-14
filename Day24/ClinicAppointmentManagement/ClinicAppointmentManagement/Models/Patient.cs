namespace ClinicAppointmentManagement.Models
{
    public class Patient
    {
        DateTime dob;
        int PatientAge;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                PatientAge = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public int Age
        {
            get { return PatientAge; }
            set 
            { 
                PatientAge = value;
            }
        }
        public string Gender { get; set; }
        public string History { get; set; }
        public ICollection<Appointment> PatientAppointments { get; set; }

    }
}
