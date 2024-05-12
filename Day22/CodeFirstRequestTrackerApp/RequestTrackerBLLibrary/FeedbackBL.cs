using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedbackBL : IFeedbackBL
    {
        readonly IRepository<int, SolutionFeedback> _feedbackRepository;
        readonly IRepository<int, Request> _requestRepository;
        readonly IRepository<int, RequestSolution> _solutionRepository;
        public FeedbackBL() 
        {
            IRepository<int, SolutionFeedback> FeedbackRepo = new Feedback_RequestSolutionGivenAndFeedbackGivenByEmployee_Repository(new RequestTrackerContext());
            IRepository<int, Request> RequestRepo = new RequestRepository(new RequestTrackerContext());
            IRepository<int, RequestSolution> SolutionRepo = new Solution_RequestRaisedAndSolutionGivenByEmployee_Repository(new RequestTrackerContext());

            _feedbackRepository = FeedbackRepo;
            _requestRepository = RequestRepo;
            _solutionRepository = SolutionRepo;
        }
        public async Task<int> AddFeedback(SolutionFeedback feedback)
        {
            RequestSolution solution = await _solutionRepository.Get(feedback.RequestSolutionId);
            if(solution == null) throw new NoRequestSolutionFoundException();
            Request request = await _requestRepository.Get(solution.RequestRaised.RequestNumber);
            if (request == null) throw new RequestDoesNotExistException();
            if (feedback.FeedbackGivenBy == request.RequestRaisedBy && solution.SolutionGivenBy != feedback.FeedbackGivenBy)
            {
                SolutionFeedback AddedFeedback = await _feedbackRepository.Add(feedback);
                if (AddedFeedback != null)
                    return AddedFeedback.FeedbackId;
                else
                    throw new InvalidFeedbackException();
            }
            throw new IncorrectUserException();
        }

        public async Task<List<SolutionFeedback>> GetAllFeedbacksOfAdminById(int AdminID)
        {
            var feedbacks = await _feedbackRepository.GetAll();
            if (feedbacks.Count == 0)
                throw new NoFeedbacksFoundException();
            var result = new List<SolutionFeedback>();
            foreach(var feedback in feedbacks)
            {
                int SolutionId = feedback.RequestSolutionId;
                RequestSolution solution = await _solutionRepository.Get(SolutionId);
                if(solution == null)
                    throw new NoRequestSolutionFoundException();
                if (solution.SolutionGivenByEmployee.Id == AdminID)
                {
                    result.Add(feedback);
                }
            }
            if (result.Count == 0)
                throw new NoFeedbacksFoundException();
            return result;
        }
    }
}
