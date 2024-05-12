using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class Solution_RequestRaisedAndSolutionGivenByEmployee_Repository : SolutionRepository
    {
        public Solution_RequestRaisedAndSolutionGivenByEmployee_Repository(RequestTrackerContext context) : base(context)
        {
        }

        public override async Task<RequestSolution> Get(int key)
        {
            var Solution = _context.Solutions.Include(s => s.RequestRaised).Include(s => s.SolutionGivenByEmployee).SingleOrDefault(s => s.RequestSolutionId == key);
            return Solution;
        }

        public override async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.Solutions.Include(s => s.RequestRaised).Include(s => s.SolutionGivenByEmployee).ToListAsync();
        }
    }
}
