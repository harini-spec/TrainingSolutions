using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeFirstRequestTrackerApp.Globals;

namespace CodeFirstRequestTrackerApp
{
    public class SolutionFrontend
    {
        ISolutionBL solutionBL;
        public SolutionFrontend()
        {
            solutionBL = new SolutionBL();
        }

        // ----------------------------------------- User - Get Solutions for a request ---------------------------------------
        public async Task GetSolutionsForUser()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the request number for which u need solution: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                var solutions = await solutionBL.GetRequestSolutionsForUser(RequestNumber, LoggedInEmployee.Id);
                await DisplaySolutions(solutions);
            }
            catch (RequestDoesNotExistException rdnee)
            {
                await Console.Out.WriteLineAsync(rdnee.Message);
            }
            catch (IncorrectUserException iue)
            {
                await Console.Out.WriteLineAsync(iue.Message);
            }
            catch(NoRequestSolutionFoundException nrsfe)
            {
                await Console.Out.WriteLineAsync(nrsfe.Message);
            }
        }

        // ----------------------------------------- Displays solutions ------------------------------------------------------
        public async Task DisplaySolution(RequestSolution solution)
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------------------");
            await Console.Out.WriteLineAsync("Solution Id       : " + solution.RequestSolutionId);
            await Console.Out.WriteLineAsync("Solution Date     : " + solution.SolutionDate);
            await Console.Out.WriteLineAsync("Solution          : " + solution.Solution);
            await Console.Out.WriteLineAsync("Solution given by : " + solution.SolutionGivenByEmployee.Name);
            await Console.Out.WriteLineAsync("User comment      : " + solution.RequestRaiserComment);
            await Console.Out.WriteLineAsync("----------------------------------------------------------------");
        }

        // ----------------------------------------- Displays 1 solution -----------------------------------------------------
        public async Task DisplaySolutions(List<RequestSolution> solutions)
        {
            foreach (var solution in solutions)
            {
                await DisplaySolution(solution);
            }
        }

        // ----------------------------------------- Admin - Get all solutions -----------------------------------------------
        public async Task GetAllSolutionsForAdmin()
        {
            try
            {
                var solutions = await solutionBL.GetRequestSolutionsForAdmin();
                await DisplaySolutions(solutions);
            }
            catch(NoRequestSolutionFoundException nrsfe)
            {
                await Console.Out.WriteLineAsync(nrsfe.Message);
            }
        }

        // ------------------------------------- Respond to solution - comment -----------------------------------------------
        public async Task RespondToSolution()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Solution Id to respond to: ");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                await Console.Out.WriteLineAsync("Enter the response: ");
                string response = Console.ReadLine();
                var result = await solutionBL.UpdateSolutionComment(RequestNumber, response, LoggedInEmployee.Id);
                await Console.Out.WriteLineAsync("Response to Solution added: ");
                await DisplaySolution(result);
            }
            catch (IncorrectUserException iue)
            {
                await Console.Out.WriteLineAsync(iue.Message);
            }
            catch (NoRequestSolutionFoundException nrsfe)
            {
                await Console.Out.WriteLineAsync(nrsfe.Message);
            }
            catch(RequestDoesNotExistException rdnee)
            {
                await Console.Out.WriteLineAsync(rdnee.Message);
            }
        }


        // ------------------------------------- Admin - Provide solution ----------------------------------------------------
        public async Task ProvideSolution()
        {
            try
            {
                RequestSolution solution = await GetSolutionDetailsFromAdmin();
                await solutionBL.AddSolution(solution);
                await Console.Out.WriteLineAsync("Solution added: ");
                solution = await solutionBL.GetRequestSolutionById(solution.RequestSolutionId);
                await DisplaySolution(solution);
            }
            catch(RequestDoesNotExistException rdne)
            {
                await Console.Out.WriteLineAsync(rdne.Message);
            }
            catch(RequestAlreadyClosedException race)
            {
                await Console.Out.WriteLineAsync(race.Message);
            }
        }

        // ------------------------------------- Get solution details from user -----------------------------------------------
        public async Task<RequestSolution> GetSolutionDetailsFromAdmin()
        {
            RequestSolution solution = new RequestSolution();
            solution.SolutionGivenBy = LoggedInEmployee.Id;
            await Console.Out.WriteLineAsync("Enter the request number: ");
            solution.RequestNumber = Convert.ToInt32((Console.ReadLine()));
            await Console.Out.WriteLineAsync("Enter the solution: ");
            solution.Solution = Console.ReadLine();
            return solution;
        }
    }
}
