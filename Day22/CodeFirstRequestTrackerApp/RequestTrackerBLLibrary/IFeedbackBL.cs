using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IFeedbackBL
    {
        public Task<int> AddFeedback(SolutionFeedback feedback);
        public Task<List<SolutionFeedback>> GetAllFeedbacksOfAdminById(int AdminID);
    }
}
