using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAppWithAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }

        public string RequestMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string Status { get; set; } = "Open";

        public int RaisedById { get; set; }
        [ForeignKey("RaisedById")]
        public Employee RaisedByEmployee { get; set; }

        public int? ClosedById { get; set; }
        [ForeignKey("ClosedById")]
        public Employee? ClosedByEmployee { get; set; }
    }
}
