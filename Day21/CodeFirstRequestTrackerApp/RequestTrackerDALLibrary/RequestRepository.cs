﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Request> Add(Request entity)
        {
            if(entity != null)
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<Request> Delete(int key)
        {
            var result = await Get(key);
            if(result != null)
            {
                _context.Requests.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Request> Get(int key)
        {
            var result = _context.Requests.SingleOrDefault(x => x.RequestNumber == key);
            if (result != null)
                return result;
            return null;    
        }

        public async Task<IList<Request>> GetAll()
        {
            var result = await _context.Requests.ToListAsync();
            if (result != null)
                return result;
            return null;
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestNumber);
            if (request != null)
            {
                // request = entity; - not required as the value is changed in the dl, just update it 
                _context.Entry<Request>(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return request;
        }
    }
}
