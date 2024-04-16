using ModelLibrary;

namespace CompanyManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Company :");
            string Company = Console.ReadLine();
            if (Company == "ABC")
            {
                ABCCompany ABC = new ABCCompany();
                ABC.BuildEmployeeFromConsole();
                ABC.PrintEmployeeDetails();            
            }
            else
            {
                XYZCompany XYZ = new XYZCompany();
                XYZ.BuildEmployeeFromConsole();
                XYZ.PrintEmployeeDetails();
            }

            
        }
    }
}
