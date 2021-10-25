using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IGenericRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
    }
}