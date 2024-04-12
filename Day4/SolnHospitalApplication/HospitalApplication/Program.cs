using HospitalApplication.Models;
using System.Numerics;

namespace HospitalApplication
{
    internal class Program
    {
        /// <summary>
        /// Gets Doctor Details from Console and initialises them to the object
        /// </summary>
        /// <param name="id">Provide Doctor's ID in int type</param>
        /// <returns></returns>
        static Doctor CreateDoctorWithConsoleDetails(int id)
        {
            Doctor doctor = new (id);

            Console.WriteLine("Enter the Doctor's Name: ");
            doctor.Name = Console.ReadLine()??"";

            Console.WriteLine("Enter the Doctor's Age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age)) {
                Console.WriteLine("Please enter a valid age: "); ; 
            }   
            doctor.Age = age;

            Console.WriteLine("Enter the Doctor's Years of Experience:");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.WriteLine("Please enter a valid experience: "); ;
            }
            doctor.Experience = exp;

            Console.WriteLine("Enter the Doctor's Qualification:");
            doctor.Qualification = Console.ReadLine()??"";

            Console.WriteLine("Enter the Doctor's Speciality:");
            doctor.Speciality = Console.ReadLine()??"";

            return doctor;
        }

        /// <summary>
        /// Prints Doctor Details based on the Speciality given by the user. Stops when the user enters -1
        /// </summary>
        /// <param name="doctor">Pass the Doctor object array</param>
        static void PrintDoctorDetailsBasedOnSpeciality(Doctor[] doctor)
        {
            Console.Write("Input a Speciality to find Doctors from the Specified Speciality. Enter -1 to exit: ");
            string speciality = Console.ReadLine() ?? "";
            while (!String.Equals(speciality, "-1"))
            {
                for (int i = 0; i < doctor.Length; i++)
                {
                    if (String.Equals(doctor[i].Speciality, speciality))
                        doctor[i].PrintDoctorDetails();
                }
                Console.Write("Input a Speciality to find Doctors from the Specified Speciality. Enter -1 to exit: ");
                speciality = Console.ReadLine() ?? "";
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the number of records: ");
            int n = Convert.ToInt16(Console.ReadLine());
            Doctor[] doctor = new Doctor[n];
            for(int i=0;i<doctor.Length; i++)
            {
                doctor[i] = CreateDoctorWithConsoleDetails(101+i);
            }
            for(int i=0;i<doctor.Length; i++)
            {
                doctor[i].PrintDoctorDetails();
            }
            PrintDoctorDetailsBasedOnSpeciality(doctor);
        }
    }
}
