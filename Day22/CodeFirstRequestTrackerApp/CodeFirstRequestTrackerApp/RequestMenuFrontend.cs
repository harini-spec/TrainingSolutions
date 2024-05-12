using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeFirstRequestTrackerApp.Globals;

namespace CodeFirstRequestTrackerApp
{
    public class RequestMenuFrontend
    {
        // ----------------------------------------- Check User -----------------------------------------
        public async Task RequestMenu()
        {
            Console.Clear();
            if (LoggedInEmployee.Role == "Admin")
            {
                await AdminRequestMenuDisplay();
            }
            else
            {
                await UserRequestMenuDisplay();
            }
        }

        // ----------------------------------------- User Request Menu -----------------------------------------
        public async Task UserRequestMenuDisplay()
        {
            int ch;
            do
            {
                await Console.Out.WriteLineAsync(
                    "1. Raise Request " +
                    "\n2. Get All Requests " +
                    "\n3. Get Request with Request Number " +
                    "\n4. View Solutions " +
                    "\n5. Give Feedback " +
                    "\n6. Respond to Solution " +
                    "\nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await new RequestFrontend().AddRequest(); break;
                    case 2: await new RequestFrontend().GetAllEmployeeRequests(); break;
                    case 3: await new RequestFrontend().GetRequestByRequestNumberForUser(); break;
                    case 4: await new SolutionFrontend().GetSolutionsForUser(); break;
                    case 5: await new FeedbackFrontend().AddFeedback(); break;
                    case 6: await new SolutionFrontend().RespondToSolution(); break;
                }
            } while (ch != -1);
        }

        // ----------------------------------------- Admin Main Request Menu -----------------------------------------
        public async Task AdminRequestMenuDisplay()
        {
            int ch;
            do
            {
                Console.Clear();
                await Console.Out.WriteLineAsync("1. User Dashboard " +
                    "\n2. Admin Dashboard" +
                    "\nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await UserDashboardDisplayForAdmin(); break;
                    case 2: await AdminDashboardDisplay(); break;
                }
            } while (ch != -1);
        }

        // ----------------------------------------- Admin Dashboard -------------------------------------------------
        private async Task AdminDashboardDisplay()
        {
            Console.Clear();
            int ch;
            do
            {
                await Console.Out.WriteLineAsync(
                    "\n1. Get All Requests " +
                    "\n2. Get All Open Requests " +
                    "\n3. Get request by Request Number " +
                    "\n4. View all solutions " +
                    "\n5. Provide solution " +
                    "\n6. View feedbacks " +
                    "\nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await new RequestFrontend().GetAllRequests(); break;
                    case 2: await new RequestFrontend().GetAllOpenRequests(); break;

                    case 3: await new RequestFrontend().GetRequestByRequestNumberForAdmin(); break;
                    case 4: await new SolutionFrontend().GetAllSolutionsForAdmin(); break;
                    case 5: await new SolutionFrontend().ProvideSolution(); break;
                    case 6: await new FeedbackFrontend().ViewFeedbacks(); break;
                }
            } while (ch != -1);
        }

        // ----------------------------------------- User Dashboard for Admin -----------------------------------------
        public async Task UserDashboardDisplayForAdmin()
        {
            Console.Clear();
            int ch;
            do
            {
                await Console.Out.WriteLineAsync(
                    "1. Raise Request " +
                    "\n2. Get your requests " +
                    "\n3. Give Feedback " +
                    "\n4. View Solutions to your Request " +
                    "\n5. Respond to solution " +
                    "\nTo Exit, -1");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: await new RequestFrontend().AddRequest(); break;
                    case 2: await new RequestFrontend().GetAllEmployeeRequests(); break;
                    case 3: await new FeedbackFrontend().AddFeedback(); break;
                    case 4: await new SolutionFrontend().GetSolutionsForUser(); break;
                    case 5: await new SolutionFrontend().RespondToSolution(); break;
                }
            } while (ch != -1);
            
        }
    }
}
