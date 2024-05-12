using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CodeFirstRequestTrackerApp.Globals;

namespace CodeFirstRequestTrackerApp
{
    public class RequestFrontend
    {
        IRequestBL requestBL;
        public RequestFrontend() 
        {
            requestBL = new RequestBL();
        }

        // ----------------------------------------- Add Request ----------------------------------------------
        public async Task AddRequest()
        {
            Request request = await GetRequestDetails();
            await requestBL.AddRequest(request);
        }
        public async Task<Request> GetRequestDetails()
        {
            Request request = new Request();
            await Console.Out.WriteLineAsync("Enter your request message: ");
            request.RequestMessage = Console.ReadLine();
            request.RequestRaisedBy = LoggedInEmployee.Id;
            return request;
        }

        // ----------------------------------------- Get all Employee Requests ---------------------------------
        public async Task GetAllEmployeeRequests()
        {
            try
            {
                var requests = await requestBL.GetAllRequestsOfEmployee(LoggedInEmployee.Id);
                await DisplayRequests(requests);
            }
            catch(EmployeeDoesNotExistException edne)
            {
                await Console.Out.WriteLineAsync(edne.Message);
            }
            catch(NoRequestsFoundException nrfe)
            {
                await Console.Out.WriteLineAsync(nrfe.Message);
            }
        }

        // ----------------------------------------- Display all Requests --------------------------------------
        public async Task DisplayRequests(List<Request> requests)
        {
            foreach (var request in requests)
            {
                await DisplayRequest(request);
            }
        }

        // ----------------------------------------- Display 1 Requests -----------------------------------------
        public async Task DisplayRequest(Request request)
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------------------");
            await Console.Out.WriteLineAsync("Request Number    : " + request.RequestNumber);
            await Console.Out.WriteLineAsync("Request Message   : " + request.RequestMessage);
            await Console.Out.WriteLineAsync("Request Date      : " + request.RequestDate);
            await Console.Out.WriteLineAsync("Request Status    : " + request.RequestStatus);
            await Console.Out.WriteLineAsync("----------------------------------------------------------------");
        }

        // ----------------------------------------- User - Get Request by Request number --------------------------
        public async Task GetRequestByRequestNumberForUser()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                var request = await requestBL.GetRequestByRequestNumberForUser(RequestNumber, LoggedInEmployee.Id);
                await DisplayRequest(request);
            }
            catch(EmployeeDoesNotExistException ednee)
            {
                await Console.Out.WriteLineAsync(ednee.Message);
            }
            catch (RequestDoesNotExistException rdnee)
            {
                await Console.Out.WriteLineAsync(rdnee.Message);
            }
            catch (IncorrectUserException iue)
            {
                await Console.Out.WriteLineAsync(iue.Message);
            }
        }

        // ----------------------------------------- Admin - Get Request by Request number -------------------------
        public async Task GetRequestByRequestNumberForAdmin()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                var request = await requestBL.GetRequestByRequestNumberForAdmin(RequestNumber);
                await DisplayRequest(request);
            }
            catch (RequestDoesNotExistException rdnee)
            {
                await Console.Out.WriteLineAsync(rdnee.Message);
            }
        }

        // ----------------------------------------- Get all requests --------------------------------------------
        public async Task GetAllRequests()
        {
            try
            {
                var requests = await requestBL.GetAllRequests();
                await DisplayRequests(requests);
            }
            catch(NoRequestsFoundException nrfe)
            {
                await Console.Out.WriteLineAsync(nrfe.Message);
            }
        }

        // ----------------------------------------- Get all open requests --------------------------------------------
        public async Task GetAllOpenRequests()
        {
            try
            {
                var requests = await requestBL.GetAllOpenRequests();
                await DisplayRequests(requests);
            }
            catch(NoRequestsFoundException nrfe)
            {
                await Console.Out.WriteLineAsync(nrfe.Message);
            }
            catch(NoOpenRequestsFoundException norf)
            {
                await Console.Out.WriteLineAsync(norf.Message);
            }
        }

        // ----------------------------------------- Close open request ----------------------------------------------
        public async Task CloseRequest()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                Request request = await requestBL.CloseRequest(RequestNumber, LoggedInEmployee.Id);
                await DisplayRequest(request);
            }
            catch (RequestAlreadyClosedException race)
            {
                await Console.Out.WriteLineAsync(race.Message);
            }
        }
    }
}
