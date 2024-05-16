using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaApplicationAPI.Contexts;
using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaContext _context;

        public UserRepository(PizzaContext context) 
        {
            _context = context;
        }
        public async Task<User> Add(User entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(int key)
        {
            try
            {
                var user = await GetById(key);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(NoUserFoundException)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAll()
        {
            var users = _context.Users.ToList();
            if (users.Count == 0)
                throw new NoUsersFoundException();
            return users;
        }

        public async Task<User> GetById(int key)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == key);
            if (user == null)
                throw new NoUserFoundException();
            return user;
        }

        public async Task<User> Update(User entity)
        {
            try
            {
                var user = await GetById(entity.Id);
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(NoUserFoundException)
            {
                throw;
            }
        }
    }
}
