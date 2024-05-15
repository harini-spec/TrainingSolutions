using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaApplicationAPI.Contexts;
using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaContext _context;

        public CustomerRepository(PizzaContext context) 
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> Delete(int key)
        {
            try
            {
                var customer = await GetById(key);
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch(NoCustomerFoundException)
            {
                throw;
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            var customers = _context.Customers.ToList();
            if (customers.Count == 0)
                throw new NoCustomersFoundException();
            return customers;
        }

        public async Task<Customer> GetById(int key)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == key);
            if (customer == null)
                throw new NoCustomerFoundException();
            return customer;
        }

        public async Task<Customer> Update(Customer entity)
        {
            try
            {
                var customer = await GetById(entity.Id);
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch(NoCustomerFoundException)
            {
                throw;
            }
        }
    }
}
