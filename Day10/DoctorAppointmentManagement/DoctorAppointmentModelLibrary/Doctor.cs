using DoctorAppointmentBLLibrary;

namespace DoctorAppointmentModelLibrary
{
    public class Doctor
    {
        public List<int> Appointments;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }

        public Doctor()
        {
            Appointments = new List<int>();
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Specialization = string.Empty;
            Qualification = string.Empty;
            Experience = 0;
        }

        public Doctor(int id, string name, int age, string specialization, string qualification, int experience, List<int> appointments)
        {
            Appointments = appointments;
            Id = id;
            Name = name;
            Age = age;
            Specialization = specialization;
            Qualification = qualification;
            Experience = experience;
        }

        /// <summary>
        /// Checks if 2 Doctor objects are same by comparing their properties
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True if they are same, else false</returns>
        public override bool Equals(object? obj)
        {
            Doctor doctor = obj as Doctor;
            if (doctor.Name == this.Name && doctor.Age == this.Age && doctor.Qualification == this.Qualification && doctor.Experience == this.Experience && doctor.Specialization == this.Specialization)
                return true;
            return false;
        }

        /// <summary>
        /// returns the properties of the Doctor
        /// </summary>
        /// <returns>Properties as string</returns>
        public override string ToString()
        {
            return Name + " " + Age + " " + Specialization + " " + Qualification + " " + Experience;
        }
    }
}