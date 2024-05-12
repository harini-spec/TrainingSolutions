using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeFirstRequestTrackerApp.Globals;

namespace CodeFirstRequestTrackerApp
{
    public class MainFrontend
    {
        IEmployeeLoginBL employeeLoginBL;
        public MainFrontend()
        {
            employeeLoginBL = new EmployeeLoginBL();
        }

        // ----------------------------------------- Main Menu -----------------------------------------
        public async Task UserMenuDisplay()
        {
            int ch;
            do
            {
                Console.Clear();
                await Console.Out.WriteLineAsync("1. Register \n2. Login \nTo Exit, -1");
                ch =  Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await GetEmployeeDetails(); break;
                    case 2: await GetLoginDetails(); break;
                }
            } while (ch != -1);
        }

        // ----------------------------------------- User Register -----------------------------------------
        async Task GetEmployeeDetails()
        {
            Employee employee = new Employee();
            await Console.Out.WriteLineAsync("Please enter your Name:");
            employee.Name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your Password:");
            employee.Password = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your Role:");
            employee.Role = Console.ReadLine();
            await EmployeeRegisterAsync(employee);
        }
        async Task EmployeeRegisterAsync(Employee employee)
        {
            var result = await employeeLoginBL.Register(employee);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Registered User Successfully! Your Id is " + result.Id);
            }
            await Task.Delay(3000);
        }

        // ----------------------------------------- User Login -----------------------------------------
        async Task GetLoginDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                LoggedInEmployee = await employeeLoginBL.GetEmployee(username);
                await Console.Out.WriteLineAsync("Login Success");
                await new RequestMenuFrontend().RequestMenu();
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
            await Task.Delay(3000);
        }
    }
}
