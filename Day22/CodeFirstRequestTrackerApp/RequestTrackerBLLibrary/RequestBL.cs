using CodeFirstRequestTrackerApp;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        readonly IRepository<int, Request> _RequestRepository;
        readonly IRepository<int, Employee> _EmployeeRepository;
        public RequestBL()
        {
            IRepository<int, Request> RequestRepo = new Request_RaisedByEmployee_Repository(new RequestTrackerContext());
            _RequestRepository = RequestRepo;
            IRepository<int, Employee> EmployeeRepo = new EmployeeRepository(new RequestTrackerContext());
            _EmployeeRepository = EmployeeRepo;
        }

        public async Task<int> AddRequest(Request request)
        {
            request.RequestStatus = "Open";
            var result = await _RequestRepository.Add(request);
            return result.RequestNumber;
        }

        public async Task<List<Request>> GetAllRequestsOfEmployee(int EmployeeId)
        {
            var employee = _EmployeeRepository.Get(EmployeeId);
            if (employee == null)
                throw new EmployeeDoesNotExistException();
            var requests = await _RequestRepository.GetAll();
            var result = new List<Request>();
            foreach (var request in requests)
            {
                if (request.RaisedByEmployee.Id == EmployeeId)
                {
                    result.Add(request);
                }
            }
            if (result.Count != 0)
                return result;
            throw new NoRequestsFoundException();
        }
        public async Task<Request> GetRequestByRequestNumberForAdmin(int requestNumber)
        {
            var result = await _RequestRepository.Get(requestNumber);
            if (result != null)
            {
                return result;
            }
            else throw new RequestDoesNotExistException();
        }

        public async Task<Request> GetRequestByRequestNumberForUser(int requestNumber, int userId)
        {
            var employee = _EmployeeRepository.Get(userId);
            if (employee == null)
                throw new EmployeeDoesNotExistException();
            var result = await _RequestRepository.Get(requestNumber);
            if (result != null)
            {
                if (result.RaisedByEmployee.Id == userId)
                    return result;
                else throw new IncorrectUserException();
            }
            else throw new RequestDoesNotExistException();
        }

        public async Task<List<Request>> GetAllRequests()
        {
            var requests = await _RequestRepository.GetAll();
            if(requests.Count != 0)
                return requests.ToList();
            throw new NoRequestsFoundException();
        }

        public async Task<List<Request>> GetAllOpenRequests()
        {
            var requests = await _RequestRepository.GetAll();
            if (requests.Count == 0)
                throw new NoRequestsFoundException();
            var result = new List<Request>();
            foreach (var request in requests)
            {
                if (request.RequestStatus == "Open")
                {
                    result.Add(request);
                }
            }
            if (result.Count == 0)
                throw new NoOpenRequestsFoundException();
            return result;
        }

        public async Task<Request> CloseRequest(int requestNumber, int RequestClosedEmployee)
        {
            var result = await _RequestRepository.Get(requestNumber);
            if (result.RequestStatus == "Closed" && result.RequestClosedBy != null)
                throw new RequestAlreadyClosedException(result.RequestClosedByEmployee.Name);
            result.RequestStatus = "Closed";
            result.ClosedDate = DateTime.Now;
            result.RequestClosedBy = RequestClosedEmployee;
            await _RequestRepository.Update(result);
            return result;
        }
    }
}