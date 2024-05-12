using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionBL
    {
        public Task<bool> isValidUser(int requestId, int userId);
        public Task<RequestSolution> UpdateSolutionComment(int solutionID, string comment, int userId);
        public Task<List<RequestSolution>> GetRequestSolutionsForUser(int RequestNumber, int userId);
        public Task<List<RequestSolution>> GetRequestSolutionsForAdmin();
        public Task<RequestSolution> AddSolution(RequestSolution solution);
        public Task<RequestSolution> GetRequestSolutionById(int SolutionId);
    }
}
