using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class SolutionFeedback
    {
        public int FeedbackId { get; set; }
        public string Feedback { get; set; }
        public int Rating { get; set; }

        public DateTime FeedbackDate { get; set; } = DateTime.Now;


        public int RequestSolutionId { get; set; }
        public RequestSolution RequestSolutionGiven {  get; set; }
        public int FeedbackGivenBy { get; set; }
        public Employee FeedbackGivenByEmployee { get; set; }
    }
}
