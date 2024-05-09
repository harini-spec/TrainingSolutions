using Microsoft.VisualBasic.FileIO;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }

        /// <summary>
        /// Prints Menu of Operations
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("0. Exit");
        }

        /// <summary>
        /// Gets choice from user to perform an operation
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateAndPrintEmployee();
                        break;
                    case 5:
                        DeleteAndPrintEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        /// <summary>
        /// Deletes the employee object and prints the resultant objects
        /// </summary>
        void DeleteAndPrintEmployee()
        {
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if(employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            DeleteEmployee(id);
            PrintAllEmployees();
        }

        /// <summary>
        /// Deletes employee object of specified employee ID
        /// </summary>
        /// <param name="id">Employee ID of int type</param>
        void DeleteEmployee(int id)
        {
            for(int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                }
            }
        }

        /// <summary>
        /// Updates and prints the updated record
        /// </summary>
        void UpdateAndPrintEmployee()
        {
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
            Console.WriteLine("Enter the updated name of the Employee: ");
            string name = Console.ReadLine()??string.Empty;
            employee.Name = name;
            PrintEmployee(employee);
        }

        /// <summary>
        /// Checks if the maximum limit is reached. If not, adds an employee record
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }

        /// <summary>
        /// Prints all employee records
        /// </summary>
        void PrintAllEmployees()
        {
            int n = employees.Length;
            int count = 0;
            for(int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                    count++;
            }
            if (count == n)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }

        /// <summary>
        /// Creates an Employee object - dependent on Employee model
        /// </summary>
        /// <param name="id">Employee ID of int type</param>
        /// <returns>Created employee object</returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        /// <summary>
        /// Prints employee details of provided object - dependent on Employee model
        /// </summary>
        /// <param name="employee">Employee object</param>
        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

        /// <summary>
        /// Gets Employee ID from the user in console
        /// </summary>
        /// <returns>Valid Employee ID</returns>
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }

        /// <summary>
        /// Searches and Prints the found employee record
        /// </summary>
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }

        /// <summary>
        /// Searches for employee record of provided Employee ID
        /// </summary>
        /// <param name="id">Employee ID of int type</param>
        /// <returns>Employee object of provided Employee ID</returns>
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                // if ( employees[i].Id == id && employees[i] != null)//Will lead to exception
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}