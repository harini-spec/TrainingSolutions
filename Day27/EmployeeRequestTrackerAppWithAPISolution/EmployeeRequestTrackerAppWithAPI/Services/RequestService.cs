using EmployeeRequestTrackerAppWithAPI.Exceptions;
using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Models.DTOs;
using EmployeeRequestTrackerAppWithAPI.Repositories;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _RequestRepository;
        private readonly IRepository<int, Employee> _EmployeeRepository;

        public RequestService(IRepository<int, Request> RequestRepository, IRepository<int, Employee> EmployeeRepository) 
        {
            _RequestRepository = RequestRepository;
            _EmployeeRepository = EmployeeRepository;
        }
        public async Task<RequestOutputWithoutCloseDetails> AddRequest(int EmployeeId, string RequestMessage)
        {
            Request request = new Request();
            request.Status = "Open";
            request.RequestMessage = RequestMessage;
            request.CreatedOn = DateTime.Now;
            request.RaisedById = EmployeeId;

            var Inserted_Request = await _RequestRepository.Add(request);

            RequestOutputWithoutCloseDetails result = MapRequestToRequestOutputWithoutCloseDetails(Inserted_Request);
            return result;
        }

        private RequestOutputWithoutCloseDetails MapRequestToRequestOutputWithoutCloseDetails(Request request)
        {
            RequestOutputWithoutCloseDetails addRequestOutput = new RequestOutputWithoutCloseDetails();
            addRequestOutput.RequestNumber = request.RequestNumber;
            addRequestOutput.RequestMessage = request.RequestMessage;
            addRequestOutput.CreatedOn = request.CreatedOn;
            addRequestOutput.RaisedById = request.RaisedById;
            addRequestOutput.Status = request.Status;
            return addRequestOutput;
        }

        public async Task<List<RequestOutputWithoutCloseDetails>> GetAllOpenRequests()
        {
            var requests = await _RequestRepository.GetAll();
            if (requests.Count() == 0)
                throw new NoRequestsFoundException();
            var result = new List<RequestOutputWithoutCloseDetails>();
            foreach (var request in requests)
            {
                if (request.Status == "Open")
                {
                    result.Add(MapRequestToRequestOutputWithoutCloseDetails(request));
                }
            }
            if (result.Count == 0)
                throw new NoOpenRequestsFoundException();
            return result.OrderBy(x => x.CreatedOn).ToList();
        }

        public async Task<List<GetRequestOutput>> GetAllRequestsOfEmployee(int EmployeeId)
        {
            var employee = await _EmployeeRepository.GetById(EmployeeId);
            if (employee == null)
                throw new NoSuchEmployeeException();
            var requests = await _RequestRepository.GetAll();
            var result = new List<GetRequestOutput>();
            foreach (var request in requests)
            {
                if (request.RaisedById == EmployeeId)
                {
                    result.Add(MapRequestToGetRequestOutput(request));
                }
            }
            if (result.Count != 0)
                return result;
            throw new NoRequestsFoundException();
        }

        private GetRequestOutput MapRequestToGetRequestOutput(Request request)
        {
            GetRequestOutput getByEmployeeIdRequestOutput = new GetRequestOutput();
            getByEmployeeIdRequestOutput.RequestNumber = request.RequestNumber; 
            getByEmployeeIdRequestOutput.RequestMessage = request.RequestMessage;
            getByEmployeeIdRequestOutput.Status = request.Status;
            getByEmployeeIdRequestOutput.CreatedOn = request.CreatedOn;
            getByEmployeeIdRequestOutput.RaisedById = request.RaisedById;
            getByEmployeeIdRequestOutput.ClosedOn = request.ClosedOn;
            getByEmployeeIdRequestOutput.ClosedById = request.ClosedById;
            return getByEmployeeIdRequestOutput;
        }

        public async Task<GetRequestOutput> CloseRequest(int requestNumber, int RequestClosedByEmployeeId)
        {
            var result = await _RequestRepository.GetById(requestNumber);
            Employee RequestClosedByEmployee = await _EmployeeRepository.GetById(RequestClosedByEmployeeId);
            if (result.Status == "Closed")
                throw new RequestAlreadyClosedException(result.ClosedByEmployee.Name);
            result.Status = "Closed";
            result.ClosedOn = DateTime.Now;
            result.ClosedById = RequestClosedByEmployeeId;
            await _RequestRepository.Update(result);
            GetRequestOutput getRequestListOutput = MapRequestToGetRequestOutput(result);
            return getRequestListOutput;
        }
    }
}
