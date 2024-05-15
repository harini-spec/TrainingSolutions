using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Repositories;

namespace PizzaApplicationAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _PizzaRepository;

        public PizzaService(IRepository<int, Pizza> PizzaRepository)
        {
            _PizzaRepository = PizzaRepository;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            await _PizzaRepository.Add(pizza);
            return pizza;
        }

        public async Task<List<Pizza>> GetAllPizzasInStock()
        {
            try
            {
                var pizzas = await _PizzaRepository.GetAll();
                var result = new List<Pizza>();
                foreach (var pizza in pizzas)
                {
                    if (pizza.InStock > 0)
                    {
                        result.Add(pizza);
                    }
                }
                if (result.Count == 0)
                {
                    throw new NoPizzaInStockException();
                }
                return result;
            }
            catch (NoPizzasFoundException)
            {
                throw;
            }
            catch (NoPizzaInStockException)
            {
                throw;
            }
        }
    }
}
