using Microsoft.EntityFrameworkCore;
using OnlineAlisverisPlatformu.Data.Context;
using OnlineAlisverisPlatformu.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
          where TEntity : BaseEntity
    {

        private readonly OSPContext _db;
        private readonly DbSet<TEntity> _dbSet; 

        public Repository(OSPContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>(); 

        }


        public void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);
            
           
        }

        public void Delete(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate); 
        }

        public TEntity GetById(int id)
        {
           return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
           entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            
        }
    }
}
