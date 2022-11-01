using Microsoft.EntityFrameworkCore;
using PaySlip.Core.Cache;
using PaySlip.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.Core.Data
{
    public class Repository<TModel, TKey> : IRepository<TModel, TKey> where TModel : BaseModel<TKey> where TKey : struct
    {
        protected DbSet<TModel> _dbSet;
        protected DbContext _dbContext;
        private readonly IModelCache<TModel, TKey> _cache;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TModel>();
        }

        public Repository(DbContext dbContext, IModelCache<TModel, TKey> cache)
        {
            _cache = cache;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TModel>();
        }

        public virtual IQueryable<TModel> Table => Entities;
        protected IQueryable<TModel> GetQuery()
        {
            return Table;
        }
        protected virtual DbSet<TModel> Entities
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = _dbContext.Set<TModel>();

                return _dbSet;
            }
        }

        /* --------------- Operational Methods ---------------- */

        public async virtual Task Add(TModel model)
        {
            _dbContext.Entry(model).State = EntityState.Added;
            await _dbContext.Set<TModel>().AddAsync(model);
        }

        public async virtual Task AddRange(List<TModel> models)
        {
            await _dbContext.Set<TModel>().AddRangeAsync(models);
        }

        public virtual IEnumerable<TModel> Find(Expression<Func<TModel, bool>> expression)
        {
            return _dbContext.Set<TModel>().Where(expression);
        }

        public virtual TModel Get(TKey key)
        {
            return _dbContext.Set<TModel>().Find(key);
        }

        public virtual IEnumerable<TModel> Get()
        {
            return _dbContext.Set<TModel>();
        }

        public virtual void Remove(TModel model)
        {
            _dbContext.Entry(model).State = EntityState.Deleted;
            _dbContext.Set<TModel>().Remove(model);
        }

        public virtual void Update(TModel model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.Set<TModel>().Update(model);
        }

        public virtual void UpdateRange(List<TModel> models)
        {
            _dbContext.Set<TModel>().UpdateRange(models);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<TModel> GetEntityCache()
        {
            if (_cache.IsEnable)
            {
                IEnumerable<TModel> models;

                if (_cache.TryGetValue(ModelCacheKey<TModel, TKey>.GetKey(), out models))
                {
                    return models;
                }
                else
                {
                    models = _dbContext.Set<TModel>().AsNoTracking().ToList();
                    _cache.Set(ModelCacheKey<TModel, TKey>.GetKey(), models);
                    return models;
                }
            }
            else
            {
                return _dbContext.Set<TModel>().AsNoTracking();
            }
        }

        public virtual void ResetEntityCache()
        {
            if (_cache.IsEnable)
            {
                IEnumerable<TModel> models = _dbContext.Set<TModel>().AsNoTracking().ToList();
                _cache.Reset(ModelCacheKey<TModel, TKey>.GetKey(), models);
            }
        }
    }
}
