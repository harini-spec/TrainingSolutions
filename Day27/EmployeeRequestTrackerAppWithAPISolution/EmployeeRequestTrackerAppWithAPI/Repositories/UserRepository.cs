using EmployeeRequestTrackerAppWithAPI.Contexts;
using EmployeeRequestTrackerAppWithAPI.Exceptions;
using EmployeeRequestTrackerAppWithAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeRequestTrackerAppWithAPI.Repositories
{
    public class UserRepository : IRepository<int, UserModel>
    {
        private RequestTrackerContext _context;

        public UserRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<UserModel> Add(UserModel item)
        {
            try
            {
                item.Status = "Disabled";
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch(Exception)
            {
                throw new DatabaseException();
            }
        }

        public async Task<UserModel> Delete(int key)
        {
            try
            {
                var user = await GetById(key);
                if (user != null)
                {
                    _context.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                throw new NoUserFoundException();
            }
            catch (NoUserFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new DatabaseException();
            }
        }

        public async Task<UserModel> GetById(int key)
        {
            try
            {
                UserModel user = await _context.Users.SingleOrDefaultAsync(u => u.EmployeeId == key);
                if (user != null)
                    return user;
                else throw new NoUserFoundException();
            }
            catch (ArgumentNullException) { throw; }
            catch (InvalidOperationException) { throw; }
            catch (OperationCanceledException) { throw; }
            catch (NoUserFoundException) { throw; }
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users.Count == 0)
                    throw new NoUsersFoundException();
                return users;
            }
            catch (NoUsersFoundException) { throw; }
            catch (ArgumentNullException) { throw; }
            catch (OperationCanceledException) { throw; }
        }

        public async Task<UserModel> Update(UserModel item)
        {
            try
            {
                var user = await GetById(item.EmployeeId);
                if (user != null)
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return user;
                }
                throw new NoUserFoundException();
            }
            catch (NoUserFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new DatabaseException();
            }
        }
    }
}
