using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Models
{
    internal class Doctor
    {

        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        public Doctor(int Id)
        {
            this.Id = Id;
        }

        public Doctor(int id, string name, int Age, int Experience, string Qualification, string Speciality) : this(id)
        {
            Name = name;
            this.Age = Age;
            this.Experience = Experience;
            this.Qualification = Qualification;
            this.Speciality = Speciality;
        }

        /// <summary>
        /// Prints Doctor Details
        /// </summary>
        public void PrintDoctorDetails()
        {
            Console.WriteLine();
            Console.WriteLine($"Name of the Doctor: \t {Name}");
            Console.WriteLine($"Age: \t\t\t {Age}");
            Console.WriteLine($"Years of experience: \t {Experience}");
            Console.WriteLine($"Qualification: \t\t {Qualification}");
            Console.WriteLine($"Speciality: \t\t {Speciality}");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine();
        }

    }
}
