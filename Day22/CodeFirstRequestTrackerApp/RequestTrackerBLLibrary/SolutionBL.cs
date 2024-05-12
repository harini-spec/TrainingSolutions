using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionBL : ISolutionBL
    {
        readonly IRepository<int, RequestSolution> _SolutionRepository;
        readonly IRepository<int, Request> _RequestRaisedByRepository;
        readonly IRepository<int, Request> _RequestClosedByRepository;
        public SolutionBL() 
        {
            IRepository<int, RequestSolution> SolutionRepo = new Solution_RequestRaisedAndSolutionGivenByEmployee_Repository(new RequestTrackerContext());
            _SolutionRepository = SolutionRepo;
            IRepository<int, Request> RequestRaisedByEmployeeRepo = new Request_RaisedByEmployee_Repository(new RequestTrackerContext());
            _RequestRaisedByRepository = RequestRaisedByEmployeeRepo;
            IRepository<int, Request> RequestClosedByEmployeeRepo = new Request_ClosedByEmployee_Repository(new RequestTrackerContext());
            _RequestClosedByRepository = RequestClosedByEmployeeRepo;
        }

        public async Task<bool> isValidUser(int requestRaiserId, int userId)
        {
            if(requestRaiserId == userId)
                return true;
            return false;
        }

        public async Task<RequestSolution> UpdateSolutionComment(int solutionID, string comment, int UserId)
        {
            var result = await _SolutionRepository.Get(solutionID);
            if (result == null) 
                throw new NoRequestSolutionFoundException();
            Request request = await _RequestRaisedByRepository.Get(result.RequestNumber);
            if (request == null)
                throw new RequestDoesNotExistException();
            if (await isValidUser(request.RequestRaisedBy, UserId))
            {
                result.RequestRaiserComment = comment;
                await _SolutionRepository.Update(result);
                return result;
            }
            throw new IncorrectUserException();
        }
        public async Task<List<RequestSolution>> GetRequestSolutionsForUser(int RequestNumber, int UserId)
        {
            Request request = await _RequestRaisedByRepository.Get(RequestNumber);
            if (request == null)
                throw new RequestDoesNotExistException();
            if (await isValidUser(request.RequestRaisedBy, UserId))
            {
                var solutions = await _SolutionRepository.GetAll();
                var result = new List<RequestSolution>();
                foreach (var solution in solutions)
                {
                    if (solution.RequestNumber == RequestNumber)
                        result.Add(solution);
                }
                if (result.Count != 0)
                    return result;
                else throw new NoRequestSolutionFoundException();
            }
            throw new IncorrectUserException();
        }
        public async Task<List<RequestSolution>> GetRequestSolutionsForAdmin() 
        {
            var solutions = await _SolutionRepository.GetAll();
            if (solutions.Count != 0)
                    return solutions.ToList();
            else throw new NoRequestSolutionFoundException();
        }

        public async Task<RequestSolution> AddSolution(RequestSolution solution)
        {
            var request = await _RequestClosedByRepository.Get(solution.RequestNumber);
            if (request == null)
                throw new RequestDoesNotExistException();
            if (request.RequestStatus == "Closed")
                throw new RequestAlreadyClosedException(request.RequestClosedByEmployee.Name);
            return await _SolutionRepository.Add(solution);
        }

        public async Task<RequestSolution> GetRequestSolutionById(int SolutionId)
        {
            RequestSolution solution = await _SolutionRepository.Get(SolutionId); ;
            if(solution != null) return solution;
            throw new NoRequestSolutionFoundException() ;
        }
    }
}
