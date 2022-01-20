using EccomerceSS.Context;
using EccomerceSS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EccomerceSS.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : BaseClass
    {
        private readonly EcommerceContext _context;

        public RepositoryBase(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<T> DeleteEntity(T entity)
        {
            await Task.FromResult(entity);
            _context.Remove(entity);
            return entity;
        }

        public async Task<List<T>> getAllAsync()
        {
            var query = _context.Set<T>().AsQueryable();
            query = getIncludesForGetAll(query);
            return await query.ToListAsync();
        }

        private IQueryable<T> getIncludesForGetAll(IQueryable<T> query)
        {
            return query;
        }

        public async Task<T> getById(int id)
        {
            var query = _context.Set<T>().AsQueryable();
            query = getIncludesForGetById(query);
            return await query.SingleOrDefaultAsync();
        }


        public async Task SaveEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        private IQueryable<T> getIncludesForGetById(IQueryable<T> query)
        {
            return query;
        }
    }
}
