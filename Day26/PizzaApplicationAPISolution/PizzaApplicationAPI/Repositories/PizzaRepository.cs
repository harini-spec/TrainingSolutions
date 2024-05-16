using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaApplicationAPI.Contexts;
using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaContext _context;
        public PizzaRepository(PizzaContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Add(Pizza entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pizza> Delete(int key)
        {
            try
            {
                var pizza = await GetById(key);
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            catch(NoPizzaFoundException)
            {
                throw;
            }
        }

        public async Task<List<Pizza>> GetAll()
        {
            var pizzas = _context.Pizzas.ToList();
            if (pizzas.Count == 0)
                throw new NoPizzasFoundException();
            return pizzas;
        }

        public async Task<Pizza> GetById(int key)
        {
            var pizza = _context.Pizzas.Where(p => p.Id == key) as Pizza;
            if (pizza == null)
                throw new NoUserFoundException();
            return pizza;
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            try
            {
                var pizza = await GetById(entity.Id);
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return pizza;
            }
            catch (NoPizzaFoundException)
            {
                throw;
            }
        }
    }
}
