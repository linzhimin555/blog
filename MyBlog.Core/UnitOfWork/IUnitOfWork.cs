using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, IBaseEntity;


        DbQuery<TQuery> Query<TQuery>() where TQuery : class;

        DatabaseFacade Database { get; }

        int Commit();

        Task<int> CommitAsync();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry Entry(object entity);
    }
}
