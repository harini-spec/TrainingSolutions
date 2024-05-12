using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class Request_RaisedByEmployee_Repository : RequestRepository
    {
        public Request_RaisedByEmployee_Repository(RequestTrackerContext context) : base(context)
        {
        }
        public override async Task<Request> Get(int key)
        {
            var Request = _context.Requests.Include(r => r.RaisedByEmployee).SingleOrDefault(r => r.RequestNumber == key);
            return Request;
        }

        public override async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.Include(r => r.RaisedByEmployee).ToListAsync();
        }
    }
}
