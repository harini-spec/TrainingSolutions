using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    //and data should be displayed using properties.
    public class Company : IGovtRules
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double BasicSalary { get; set; }
        public string CompanyName { get; set; }
        public double PF { get; set; }
        public double ServiceCompletedYears { get; set; }
        public double GratuityAmount { get; set; }
        public double Salary {  get; set; }

        public Company()
        {
            EmpID = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            BasicSalary = 0;
            CompanyName = string.Empty;
            ServiceCompletedYears = 0;
        }

        public Company(string name, string department, string designation, double basicSalary, int serviceCompletedYears)
        {
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
            ServiceCompletedYears = serviceCompletedYears;
        }

        /// <summary>
        /// Creates an Employee object
        /// </summary>
        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Enter your Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your Department:");
            Department = Console.ReadLine();
            Console.WriteLine("Enter your Designation:");
            Designation = Console.ReadLine();
            Console.WriteLine("Enter your Basic Salary:");
            BasicSalary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your Service Completed Years:");
            ServiceCompletedYears = Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Prints the provided employee record
        /// </summary>
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine($"Name \t\t\t\t\t\t: {Name}");
            Console.WriteLine($"Department \t\t\t\t\t: {Department}");
            Console.WriteLine($"Designation \t\t\t\t\t: {Designation}");
            Console.WriteLine($"Basic Salary \t\t\t\t\t: {BasicSalary}");
            Console.WriteLine($"Service Completed Years \t\t\t: {ServiceCompletedYears}");
            Console.WriteLine($"Company Name \t\t\t\t\t: {CompanyName}");
            Console.WriteLine($"Salary after PF deduction and Gratuity added \t: {Salary}");
            if(GratuityAmount == -1)
                Console.WriteLine($"Gratuity Amount \t\t\t\t: Not Applicable");
            else
                Console.WriteLine($"Gratuity Amount \t\t\t\t: {GratuityAmount}");
            Console.WriteLine($"Total PF Amount \t\t\t\t: {PF}");
        }

        public double EmployeePF(double basicSalary)
        {
            throw new NotImplementedException();
        }

        public string LeaveDetails()
        {
            throw new NotImplementedException();
        }

        public double CalculateGratuityAmount(double serviceCompleted, double basicSalary)
        {
            throw new NotImplementedException();
        }
    }
}
