using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAppWithAPI.Models.DTOs
{
    public class RequestOutputWithoutCloseDetails
    {
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public int RaisedById { get; set; }

        public string Status { get; set; } = "Open";
    }
}
