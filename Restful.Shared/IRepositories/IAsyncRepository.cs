using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.IRepositories
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid ID);
        Task<IReadOnlyList<TEntity>> ListAllAsync();

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);


    }
}
