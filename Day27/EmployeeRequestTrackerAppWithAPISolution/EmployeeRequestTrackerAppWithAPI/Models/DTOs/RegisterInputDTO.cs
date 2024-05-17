namespace EmployeeRequestTrackerAppWithAPI.Models.DTOs
{
    public class RegisterInputDTO : RegisterDTO
    {
        public string Password { get; set; }
        // returns password to - to overcome this, empty pwd string or
        // create a new DTO without pwd for returning the data
    }
}
