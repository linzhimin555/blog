using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity> where TEntity : class, IBaseEntity<TKey>
    {

        public Repository(IUnitOfWork context) : base(context)
        {

        }
        public virtual List<TEntity> Get(IEnumerable<TKey> ids)
        {
            return AsQueryable().Where(o => ids.Contains(o.Id)).ToList();
        }

        public virtual async Task<List<TEntity>> GetAsync(IEnumerable<TKey> ids)
        {
            return await AsQueryable().Where(o => ids.Contains(o.Id)).ToListAsync();
        }

        public void Remove(IEnumerable<TKey> ids)
        {
            var ls = Get(ids);
            Remove(ls);
        }

        public async Task RemoveAsync(IEnumerable<TKey> ids)
        {
            var ls = await GetAsync(ids);
            Remove(ls);
        }
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly IUnitOfWork _context;

        protected readonly DbSet<TEntity> Table;

        protected DatabaseFacade Database { get; }

        public Repository(IUnitOfWork context)
        {
            _context = context;
            Table = context.Set<TEntity>();
            Database = context.Database;
        }


        public virtual void Add(TEntity entity)
        {
            Table.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            Table.AddRange(entities);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            Table.Update(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
        }

        public virtual void Remove(object key)
        {
            Remove(Get(key));
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
                return;

            Table.Remove(entity);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                return;
            if (!entities.Any())
                return;
            Table.RemoveRange(entities);
        }

        public virtual TEntity Get(object key)
        {
            return Table.Find(key);
        }

        public virtual async Task<TEntity> GetAsync(object key)
        {
            return await Table.FindAsync(key);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> @where = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = AsQueryable();
            foreach (var include in includes)
                queryable = queryable.Include(include);
            return queryable.FirstOrDefault(where);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = AsQueryable();
            foreach (var include in includes)
                queryable = queryable.Include(include);
            return await queryable.FirstOrDefaultAsync(where);
        }

        public bool Exist(Expression<Func<TEntity, bool>> @where = null)
        {
            if (where != null)
                return Table.Any(where);
            return Table.Any();
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> @where = null)
        {
            if (where != null)
                return await Table.AnyAsync(where);
            return await Table.AnyAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> @where = null)
        {
            if (where != null)
                return Table.Count(where);
            return Table.Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> where = null)
        {
            if (where != null)
                return await Table.CountAsync(where);
            return await Table.CountAsync();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return Table.AsQueryable();
        }

        protected DbQuery<TQuery> Query<TQuery>() where TQuery : class
        {
            return _context.Query<TQuery>();
        }
    }
}
