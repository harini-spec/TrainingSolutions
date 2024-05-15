using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Services
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetAllPizzasInStock();
        Task<Pizza> AddPizza(Pizza pizza);
    }
}
