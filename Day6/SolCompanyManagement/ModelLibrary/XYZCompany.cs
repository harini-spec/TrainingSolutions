using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class XYZCompany : Company
    {
        public double EmployeeContribution { get; set; }
        public double EmployerContribution { get; set; }
        public XYZCompany() 
        {
            CompanyName = "XYZ";
        }

        public XYZCompany(string name, string department, string designation, double basicSalary, double pf, double gratuityAmount, double salary, int serviceCompletedYears, double employeeContribution, double employerContribution) : base(name, department, designation, basicSalary, serviceCompletedYears)
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
            Salary = basicSalary - (basicSalary * 12 / 100);
            EmployeeContribution = basicSalary * 12/100;
            EmployerContribution = basicSalary * 12/100;
            return EmployeeContribution + EmployerContribution;
        }

        /// <summary>
        /// Calculates Gratuity Amount with respect to service years
        /// </summary>
        /// <param name="serviceCompleted">no of service years completed in the same company as int type</param>
        /// <param name="basicSalary">Basic Salary as double type</param>
        /// <returns>-1 as it is Not Applicable for XYZ company</returns>
        public double CalculateGratuityAmount(double serviceCompleted, double basicSalary)
        {
            return -1;
        }

        /// <summary>
        /// Prints Leave Details of the Company
        /// </summary>
        /// <returns>Leave Details as string type</returns>
        public string LeaveDetails()
        {
            return "2 days of Casual Leave per month " +
                "\n\t\t\t\t\t\t  5 days of Sick Leave per year " +
                "\n\t\t\t\t\t\t  5 days of Privilege Leave per year";
        }
    }
}
