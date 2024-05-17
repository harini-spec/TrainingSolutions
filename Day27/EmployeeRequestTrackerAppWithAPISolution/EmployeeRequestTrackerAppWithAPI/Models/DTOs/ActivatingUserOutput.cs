namespace EmployeeRequestTrackerAppWithAPI.Models.DTOs
{
    public class ActivatingUserOutput
    {
        public int ActivatedUserId { get; set; }
        public string ActivatedUser { get; set; }
        public string ActivatedBy { get; set; }
        public DateTime ActivatedOn { get; set; }
        public string Role { get; set; }
    }
}
