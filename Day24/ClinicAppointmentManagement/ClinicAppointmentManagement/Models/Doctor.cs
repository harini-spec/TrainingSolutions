using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClinicAppointmentManagement.Models
{
    public class Doctor
    {
        int DoctorAge;
        DateTime dob;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { 
            get => dob;
            set
            {
                dob = value;
                DoctorAge = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public int Age {
            get { return DoctorAge; }
            set { DoctorAge = value; }
        }
        public string Gender;
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }

        public ICollection<Appointment> DoctorAppointments { get; set; }
    }
}
