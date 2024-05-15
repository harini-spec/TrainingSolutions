namespace PizzaApplicationAPI.Models.DTOs
{
    public class CustomerLoginDTO
    {
        public int UserId { get; set; }
        public string password { get; set; } = string.Empty;
    }
}
