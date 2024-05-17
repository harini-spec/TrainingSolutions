using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Models.DTOs;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public interface IRequestService
    {
        public Task<RequestOutputWithoutCloseDetails> AddRequest(int EmployeeId, string RequestMessage);
        public Task<List<GetRequestOutput>> GetAllRequestsOfEmployee(int EmployeeId);
        public Task<List<RequestOutputWithoutCloseDetails>> GetAllOpenRequests();
        public Task<GetRequestOutput> CloseRequest(int requestNumber, int RequestClosedByEmployeeId);
    }
}
