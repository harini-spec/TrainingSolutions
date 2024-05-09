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
        readonly IRepository<int,  Request> _repository;
        public RequestBL() 
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<int> AddRequest(Request request)
        {
            request.RequestStatus = "Open";
            var result = await _repository.Add(request);
            return result.RequestNumber;
        }

        public async Task<Request> CloseRequest(int requestNumber, int RequestClosedEmployee)
        {
            var result = await _repository.Get(requestNumber);
            if (result.RequestStatus == "Close" && result.RequestClosedBy != null)
                throw new RequestAlreadyClosedException(result.RequestClosedBy);
            result.RequestStatus = "Close";
            result.ClosedDate = DateTime.Now;
            result.RequestClosedBy = RequestClosedEmployee;
            _repository.Update(result);
            return result;
        }

        public async Task<List<Request>> GetAllRequestsOfEmployee(int EmployeeId)
        {
            var requests = await _repository.GetAll();
            var result = new List<Request>();
            foreach(var request in requests)
            {
                if(request.RequestRaisedBy == EmployeeId)
                {
                    result.Add(request);
                }
            }
            return result;
        }

        public async Task<Request> GetRequest(int requestNumber)
        {
            var result = await _repository.Get(requestNumber);
            if (result != null)
                return result;
            throw new RequestDoesNotExistException();
        }

        public async Task<List<Request>> GetAllRequests()
        {
            var requests = await _repository.GetAll();
            return requests.ToList();
        }

        public async Task<List<Request>> GetAllOpenRequests()
        {
            var requests = await _repository.GetAll();
            var result = new List<Request>();   
            foreach( var request in requests)
            {
                if(request.RequestStatus == "Open")
                {
                    result.Add(request);
                }
            }
            return result;
        }
    }
}
