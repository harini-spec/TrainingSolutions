using EmployeeRequestTrackerAppWithAPI.Contexts;
using EmployeeRequestTrackerAppWithAPI.Exceptions;
using EmployeeRequestTrackerAppWithAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAppWithAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        protected readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Request> Add(Request entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
                
            }
            catch (Exception)
            {
                throw new DatabaseException();
            }
        }

        public async Task<Request> Delete(int key)
        {
            try
            {
                var result = await GetById(key);
                _context.Requests.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw new DatabaseException();
            }
        }

        public async Task<Request> GetById(int key)
        {
            try
            {
                var result = _context.Requests.Include(r => r.ClosedByEmployee).SingleOrDefault(r => r.RequestNumber == key);
                if (result != null)
                    return result;
                throw new NoRequestFoundException();
            }
            catch (ArgumentNullException) { throw; }
            catch (InvalidOperationException) { throw; }
            catch (OperationCanceledException) { throw; }
            catch (NoRequestFoundException) { throw; }
        }

        public async Task<IEnumerable<Request>> GetAll()
        {
            try
            {
                var result = await _context.Requests.ToListAsync();
                if (result.Count != 0)
                    return result.ToList();
                throw new NoRequestsFoundException();
            }
            catch (ArgumentNullException) { throw; }
            catch (OperationCanceledException) { throw; }
            catch (NoRequestsFoundException) { throw; }
        }

        public async Task<Request> Update(Request entity)
        {
            try
            {
                var request = await GetById(entity.RequestNumber);
                if (request != null)
                {
                    _context.Entry<Request>(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return entity;
                }
                throw new NoSuchEmployeeException();
            }
            catch (NoSuchEmployeeException)
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
