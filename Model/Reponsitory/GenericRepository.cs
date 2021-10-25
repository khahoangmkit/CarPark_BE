using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.DBContext;

namespace Model.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private CarParkDbContext _dbContext;

        protected CarParkDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = new CarParkDbContext()); }
        }


        public GenericRepository(CarParkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }
        
        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}