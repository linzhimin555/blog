using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public class UnitOfWorkBase : DbContext, IUnitOfWork
    {
        private readonly Dictionary<Type, IRepository> _repositories;

        public UnitOfWorkBase(DbContextOptions options) : base(options)
        {

        }

        public virtual int Commit()
        {
            return SaveChanges();
        }

        public virtual async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repo = new Repository<TEntity>(this);
                _repositories[type] = repo;
                return repo;
            }
            return _repositories[type] as IRepository<TEntity>;
        }
    }
}
