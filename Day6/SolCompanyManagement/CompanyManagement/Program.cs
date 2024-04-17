using ModelLibrary;

namespace CompanyManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Company :");
            string Company = Console.ReadLine();

            // By passing Company object to interface 
            // Here we are passing the object and getting it in IGovtRules Interface reference - Inner logic will be hidden 
            CompanyGovtRules companyGovtRules = new CompanyGovtRules();

            if (Company == "ABC")
            {
                Company ABC = new ABCCompany();
                ABC.BuildEmployeeFromConsole();
                companyGovtRules.CalculateBenefits(ABC, ABC.BasicSalary, ABC.ServiceCompletedYears);
                ABC.PrintEmployeeDetails();
            }
            else
            {
                XYZCompany XYZ = new XYZCompany();
                XYZ.BuildEmployeeFromConsole();
                companyGovtRules.CalculateBenefits(XYZ, XYZ.BasicSalary, XYZ.ServiceCompletedYears);
                XYZ.PrintEmployeeDetails();
            }
        }
    }
}
