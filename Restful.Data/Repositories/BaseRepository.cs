using Microsoft.EntityFrameworkCore;
using Restful.Shared.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Data.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly RestfulDbContext _restfulDbContext;
        public BaseRepository(RestfulDbContext myDbContext)
        {
            _restfulDbContext = myDbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _restfulDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _restfulDbContext.Set<T>().ToListAsync();
        }



        public async Task<T> AddAsync(T entity)
        {
            await _restfulDbContext.Set<T>().AddAsync(entity);
            await _restfulDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _restfulDbContext.Set<T>().AddRangeAsync(entities);
            await _restfulDbContext.SaveChangesAsync();

            return entities;
        }


        public async Task DeleteAsync(T entity)
        {
            _restfulDbContext.Set<T>().Remove(entity);
            await _restfulDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _restfulDbContext.Update(entity);
            await _restfulDbContext.SaveChangesAsync();

        }




    }
}
