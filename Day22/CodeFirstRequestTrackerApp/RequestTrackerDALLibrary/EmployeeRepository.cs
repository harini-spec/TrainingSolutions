﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public virtual async Task<Employee> Get(int key)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == key);
            return employee;
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await Get(entity.Id); // just to check if it is present 
            if (employee != null)
            {
                _context.Entry<Employee>(entity).State = EntityState.Modified; 
                // it'll check for the primary key using where clause and update this record
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}