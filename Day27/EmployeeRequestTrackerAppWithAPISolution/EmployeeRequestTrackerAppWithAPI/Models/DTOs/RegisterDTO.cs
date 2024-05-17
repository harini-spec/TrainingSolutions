namespace EmployeeRequestTrackerAppWithAPI.Models.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
    }
}
