using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class Feedback_RequestSolutionGivenAndFeedbackGivenByEmployee_Repository : FeedbackRepository
    {
        public Feedback_RequestSolutionGivenAndFeedbackGivenByEmployee_Repository(RequestTrackerContext context) : base(context)
        {
        }

        public override async Task<SolutionFeedback> Get(int key)
        {
            var feedback = _context.SolutionFeedbacks.Include(f => f.RequestSolutionGiven).Include(f => f.FeedbackGivenByEmployee).SingleOrDefault(f => f.FeedbackId == key);
            return feedback;
        }

        public override async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.SolutionFeedbacks.Include(f => f.RequestSolutionGiven).Include(f => f.FeedbackGivenByEmployee).ToListAsync();
        }
    }
}
