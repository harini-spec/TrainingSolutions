using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class ABCCompany : Company
    {
        public double EmployeeContribution { get; set; }
        public double EmployerContribution { get; set; }
        public ABCCompany() 
        {
            CompanyName = "ABC";
        }

        public ABCCompany(string name, string department, string designation, double basicSalary, double pf, double gratuityAmount, double salary, int serviceCompletedYears, double employeeContribution, double employerContribution) : base(name, department, designation, basicSalary, serviceCompletedYears)
        {
            PF = pf;
            GratuityAmount = gratuityAmount;
            Salary = salary;
            EmployeeContribution = employeeContribution;
            EmployerContribution = employerContribution;
        }

        /// <summary>
        /// Overrides Company class method, calls the Company class method and adds PF and Gratuity Amount to the object
        /// </summary>
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            PF = EmployeePF(BasicSalary);
            GratuityAmount = CalculateGratuityAmount(ServiceCompletedYears, BasicSalary);
        }

        /// <summary>
        /// Overrides Company class method, calls the Company class method and prints PF and Leave Details
        /// </summary>
        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine($"Employee's Contribution to PF \t\t\t: {EmployeeContribution}");
            Console.WriteLine($"Employer's Contribution to PF \t\t\t: {EmployerContribution}");
            Console.WriteLine($"Leave Details \t\t\t\t\t: {LeaveDetails()}");
        }

        /// <summary>
        /// Calculates Employee's and Employer's Contribution to PF 
        /// </summary>
        /// <param name="basicSalary">Basic Salary as double type</param>
        /// <returns>Total PF as double type</returns>
        public double EmployeePF(double basicSalary)
        {
            Salary = basicSalary - (basicSalary * 3.67/100);
            EmployeeContribution = basicSalary * 3.67/100;
            EmployerContribution = basicSalary * 8.33/100;
            return EmployerContribution + EmployeeContribution;
        }

        /// <summary>
        /// Calculates Gratuity Amount with respect to service years
        /// </summary>
        /// <param name="serviceCompleted">no of service years completed in the same company as int type</param>
        /// <param name="basicSalary">Basic Salary as double type</param>
        /// <returns>Calculated Gratuity Amount as double</returns>
        public double CalculateGratuityAmount(double serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
                GratuityAmount = 3 * BasicSalary;
            else if (serviceCompleted > 10)
                GratuityAmount = 2 * BasicSalary;
            else if (serviceCompleted > 5)
                GratuityAmount = BasicSalary;
            else
                GratuityAmount = 0;
            Salary += GratuityAmount;
            return GratuityAmount;
        }

        /// <summary>
        /// Prints Leave Details of the Company
        /// </summary>
        /// <returns>Leave Details as string type</returns>
        public string LeaveDetails()
        {
            return "1 day of Casual Leave per Month " +
                "\n\t\t\t\t\t\t  12 days of Sick Leave per Year " +
                "\n\t\t\t\t\t\t  10 days of Privilege Leave per year";
        }
    }
}
