using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAppWithAPI.Models.DTOs
{
    public class GetRequestOutput
    {
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public int RaisedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; } = "Open";
        public int? ClosedById { get; set; }
        public DateTime? ClosedOn { get; set; }
    }
}
