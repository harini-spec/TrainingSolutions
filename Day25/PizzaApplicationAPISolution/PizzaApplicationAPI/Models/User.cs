using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApplicationAPI.Models
{
    public class User
    {
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }
        public string Status { get; set; }

    }
}
