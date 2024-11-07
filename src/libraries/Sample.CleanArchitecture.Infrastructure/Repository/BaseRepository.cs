﻿using Microsoft.EntityFrameworkCore;
using Sample.CleanArchitecture.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.CleanArchitecture.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        readonly DbSet<T> _dbSet;
        public readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual IQueryable<T> Query() => _dbSet;

        public virtual async Task<T> FirstOrDefaultAsync(object id) =>
            await _dbSet.FindAsync(id);

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            var query = orderBy(Query());
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query().Where(predicate).ToListAsync();
        }        

        public virtual async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task InsertRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task UpdateRangeAsync(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await this.FirstOrDefaultAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteRangeAsync(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}