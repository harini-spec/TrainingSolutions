using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaApplicationAPI.Contexts;
using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;

namespace PizzaApplicationAPI.Repositories
{
    public class UserCredentialRepository : IRepository<int, UserCredential>
    {
        private readonly PizzaContext _context;
        public UserCredentialRepository(PizzaContext context) 
        {
            _context = context;
        }
        public async Task<UserCredential> Add(UserCredential entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserCredential> Delete(int key)
        {
            try
            {
                var user_credential = await GetById(key);
                _context.Remove(user_credential);
                await _context.SaveChangesAsync();
                return user_credential;
            }
            catch(NoUserCredentialFoundException) 
            {
                throw;
            }
        }

        public async Task<List<UserCredential>> GetAll()
        {
            var user_credential = _context.UserCredentials.ToList();
            if (user_credential.Count == 0)
                throw new NoUserCredentialsFoundException();
            return user_credential;
        }

        public async Task<UserCredential> GetById(int key)
        {
            UserCredential user_credential = _context.UserCredentials.SingleOrDefault(u => u.CustomerId == key);
            if(user_credential == null) throw new NoUserCredentialFoundException();
            return user_credential;
        }

        public async Task<UserCredential> Update(UserCredential entity)
        {
            try
            {
                var user_credential = await GetById(entity.CustomerId);
                _context.Update(user_credential);
                await _context.SaveChangesAsync();
                return user_credential;
            }
            catch(NoUserCredentialFoundException)
            {
                throw;
            }
        }
    }
}
