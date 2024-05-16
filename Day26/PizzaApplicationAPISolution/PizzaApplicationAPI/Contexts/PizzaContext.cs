using Microsoft.EntityFrameworkCore;
using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Contexts
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

    }
}
