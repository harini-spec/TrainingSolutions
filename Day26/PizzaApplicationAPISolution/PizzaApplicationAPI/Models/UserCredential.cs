using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApplicationAPI.Models
{
    public class UserCredential
    {
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User customer { get; set; }
        public string Status { get; set; }

    }
}
