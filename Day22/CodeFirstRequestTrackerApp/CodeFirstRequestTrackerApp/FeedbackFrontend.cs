using static CodeFirstRequestTrackerApp.Globals;
using RequestTrackerBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;

namespace CodeFirstRequestTrackerApp
{
    public class FeedbackFrontend
    {
        IFeedbackBL feedbackBL;
        ISolutionBL solutionBL;
        public FeedbackFrontend()
        {
            feedbackBL = new FeedbackBL();
            solutionBL = new SolutionBL();
        }

        // ----------------------------------------- Add Feedback ----------------------------------------------
        public async Task AddFeedback()
        {
            try
            {
                var feedback = await GetFeedbackDetailsFromUser();
                await feedbackBL.AddFeedback(feedback);
                Console.Out.WriteLineAsync("Feedback successfully added");
            }
            catch (InvalidFeedbackException ife)
            {
                await Console.Out.WriteLineAsync(ife.Message);
            }
            catch (IncorrectUserException iue)
            {
                await Console.Out.WriteLineAsync(iue.Message);
            }
            catch (NoRequestSolutionFoundException nrsfe)
            { 
                Console.Out.WriteLineAsync(nrsfe.Message); 
            }
            catch(RequestDoesNotExistException rdnee)
            {  
                Console.Out.WriteLineAsync(rdnee.Message); 
            }

        }

        // -------------------------------- Get feedback details from user --------------------------------------
        public async Task<SolutionFeedback> GetFeedbackDetailsFromUser()
        {
            SolutionFeedback feedback = new SolutionFeedback();
            await Console.Out.WriteLineAsync("Enter the Solution for which u want to provide feedback: ");
            feedback.RequestSolutionId = Convert.ToInt32(Console.ReadLine());
            feedback.FeedbackGivenBy = LoggedInEmployee.Id;
            await Console.Out.WriteLineAsync("Enter the feedback: ");
            feedback.Feedback = Console.ReadLine();
            await Console.Out.WriteLineAsync("Enter the feedback rating: ");
            feedback.Rating = Convert.ToInt32(Console.ReadLine());
            return feedback;
        }

        // -------------------------------- Admin - view feedbacks given to them ---------------------------------
        public async Task ViewFeedbacks()
        {
            try
            {
                List<SolutionFeedback> feedbacks = await feedbackBL.GetAllFeedbacksOfAdminById(LoggedInEmployee.Id);
                DisplayFeedbacks(feedbacks);
            }
            catch(NoFeedbacksFoundException nffe)
            {
                await Console.Out.WriteLineAsync(nffe.Message);
            }
            catch(NoRequestSolutionFoundException  nrsfe) 
            {
                await Console.Out.WriteLineAsync(nrsfe.Message);
            }
        }

        // ------------------------------------------- Display feedbacks ------------------------------------------
        private async Task DisplayFeedbacks(List<SolutionFeedback> feedbacks)
        {
            foreach(var feedback in feedbacks)
            {
                await DisplayFeedbacks(feedback);
            }
        }

        // ------------------------------------------- Display 1 feedback ------------------------------------------
        private async Task DisplayFeedbacks(SolutionFeedback feedback)
        {
            try
            {
                RequestSolution solution = await solutionBL.GetRequestSolutionById(feedback.RequestSolutionId);
                await Console.Out.WriteLineAsync("----------------------------------------------------------------");
                await Console.Out.WriteLineAsync("Solution provided: " + solution.Solution);
                await Console.Out.WriteLineAsync("Feedback date : " + feedback.FeedbackDate);
                await Console.Out.WriteLineAsync("Feedback : " + feedback.Feedback);
                await Console.Out.WriteLineAsync("Rating   : " + feedback.Rating);
                await Console.Out.WriteLineAsync("----------------------------------------------------------------");
            }
            catch(NoRequestSolutionFoundException nrsfe)
            {
                await Console.Out.WriteLineAsync(nrsfe.Message);
            }
        }
    }
}
