using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace RequestTrackerFEAPP
{
    public class Program
    {
        IEmployeeLoginBL employeeLoginBL;
        IRequestBL requestBL;
        public Employee LoggedInEmployee;
        public Program()
        {
            employeeLoginBL = new EmployeeLoginBL();
            requestBL = new RequestBL();
            LoggedInEmployee = new Employee();
        }

        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                LoggedInEmployee = await employeeLoginBL.GetEmployee(username);
                await Console.Out.WriteLineAsync("Login Success");
                await RequestMenu();
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        async Task GetLoginDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }

        async Task EmployeeRegisterAsync(Employee employee)
        { 
            var result = await employeeLoginBL.Register(employee);
            if(result != null)
            {
                await Console.Out.WriteLineAsync("Registered User Successfully! Your Id is " + result.Id);
            }
        }
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

        public async Task UserMenuDisplay()
        {
            int ch;
            do
            {
                Console.Clear();
                await Console.Out.WriteLineAsync("1. Register \n2. Login \nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await GetEmployeeDetails(); break;
                    case 2: await GetLoginDetails(); break;
                }
            } while (ch != -1);
        }

        public async Task RequestMenu()
        {
            Console.Clear();
            if (LoggedInEmployee.Role == "Admin")
            {
                await AdminRequestMenuDisplay();
            }
            else
            {
                await UserRequestMenuDisplay();
            }
        }
            
        public async Task UserRequestMenuDisplay()
        {
            int ch;
            do
            {
                await Console.Out.WriteLineAsync(
                    "1. Add Request " +
                    "\n2. Get All Requests " +
                    "\n3. Get Request with Request Number " +
                    "\nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await AddRequest(); break;
                    case 2: await GetAllEmployeeRequests(); break;
                    case 3: await GetRequestByRequestNumber(); break;
                    
                }
            } while (ch != -1);
        }

        public async Task AdminRequestMenuDisplay()
        {
            int ch;
            do
            {
                await Console.Out.WriteLineAsync(
                    "1. Close Request " +
                    "\n2. Get All Open Requests " +
                    "\n3. Get All Requests " +
                    "\nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await CloseRequest(); break;
                    case 2: await GetAllOpenRequests(); break;
                    case 3: await GetAllRequests(); break;

                }
            } while (ch != -1);
        }

        public async Task GetAllRequests()
        {
            var requests = await requestBL.GetAllRequests();
            await DisplayRequests(requests);
        }

        public async Task DisplayRequests(List<Request> requests)
        {
            foreach (var request in requests)
            {
                await DisplayRequest(request);
            }
        }

        public async Task DisplayRequest(Request request)
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------------------");
            await Console.Out.WriteLineAsync("Request Number: " + request.RequestNumber);
            await Console.Out.WriteLineAsync("Request Message: " + request.RequestMessage);
            await Console.Out.WriteLineAsync("Request Date: " + request.RequestDate);
            await Console.Out.WriteLineAsync("Request Status: " + request.RequestStatus);
            await Console.Out.WriteLineAsync("----------------------------------------------------------------");
        }

        public async Task GetAllOpenRequests()
        {
            var requests = await requestBL.GetAllOpenRequests();
            await DisplayRequests(requests);
        }

        public async Task GetRequestByRequestNumber()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                var request = await requestBL.GetRequest(RequestNumber);
                await DisplayRequest(request);
            }
            catch(RequestDoesNotExistException rdnee)
            {
                await Console.Out.WriteLineAsync(rdnee.Message);
            }
        }

        public async Task GetAllEmployeeRequests()
        {
            var requests = await requestBL.GetAllRequestsOfEmployee(LoggedInEmployee.Id);
            await DisplayRequests(requests);
        }

        public async Task CloseRequest()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                Request request = await requestBL.CloseRequest(RequestNumber, LoggedInEmployee.Id);
                await DisplayRequest(request);
            }
            catch(RequestAlreadyClosedException race)
            {
                await Console.Out.WriteLineAsync(race.Message);
            }
        }

        public async Task<Request> GetRequestDetails()
        {
            Request request = new Request();
            await Console.Out.WriteLineAsync("Enter your request message: ");
            request.RequestMessage = Console.ReadLine();
            request.RequestRaisedBy = LoggedInEmployee.Id;
            return request;
        }

        public async Task AddRequest()
        {
            Request request = await GetRequestDetails();
            await requestBL.AddRequest(request);
        }

        static async Task Main(string[] args)
        {
            await new Program().UserMenuDisplay();
        }
    }
}