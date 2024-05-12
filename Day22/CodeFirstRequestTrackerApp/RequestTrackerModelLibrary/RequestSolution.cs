using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class RequestSolution
    {
        [Key]
        public int RequestSolutionId { get; set; }
        public string Solution { get; set; }
        public DateTime SolutionDate { get; set; } = DateTime.Now;
        public bool isSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }


        public int RequestNumber { get; set; }
        public Request RequestRaised { get; set; }

        public int SolutionGivenBy { get; set; }
        public Employee SolutionGivenByEmployee { get; set; }

        public ICollection<SolutionFeedback> FeedbacksGiven { get; set; }//No effect on the table
    }
}
