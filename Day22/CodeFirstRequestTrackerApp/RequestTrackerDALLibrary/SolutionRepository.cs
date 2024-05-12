using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionRepository: IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;

        public SolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var Solution = await Get(key);
            if (Solution != null)
            {
                _context.Solutions.Remove(Solution);
                await _context.SaveChangesAsync();
            }
            return Solution;
        }

        public virtual async Task<RequestSolution> Get(int key)
        {
            var Solution = _context.Solutions.SingleOrDefault(s => s.RequestSolutionId == key);
            return Solution;
        }

        public virtual async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.Solutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var solution = await Get(entity.RequestSolutionId);
            if (solution != null)
            {
                _context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
