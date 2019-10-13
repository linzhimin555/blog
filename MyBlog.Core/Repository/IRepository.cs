using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public interface IRepository<TEntity> : IRepository where TEntity : class, IBaseEntity
    {

        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        Task AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Remove(object key);

        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        TEntity Get(object key);

        Task<TEntity> GetAsync(object key);

        TEntity Get(Expression<Func<TEntity, bool>> @where = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where = null, params Expression<Func<TEntity, object>>[] includes);

        bool Exist(Expression<Func<TEntity, bool>> @where = null);

        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> @where = null);

        int Count(Expression<Func<TEntity, bool>> @where = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> @where = null);

        IQueryable<TEntity> AsQueryable();
    }
    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : class, IBaseEntity<TKey>
    {
        void Remove(IEnumerable<TKey> ids);

        Task RemoveAsync(IEnumerable<TKey> ids);

        List<TEntity> Get(IEnumerable<TKey> ids);

        Task<List<TEntity>> GetAsync(IEnumerable<TKey> ids);
    }
    public interface IRepository { }
}
