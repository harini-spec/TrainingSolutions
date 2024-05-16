namespace PizzaApplicationAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }
        public string password { get; set; } = string.Empty;
    }
}
