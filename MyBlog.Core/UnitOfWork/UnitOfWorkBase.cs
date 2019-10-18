using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public class UnitOfWorkBase : DbContext, IUnitOfWork
    {
        private readonly Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

        private readonly IHttpContextAccessor _accessor;

        public UnitOfWorkBase(DbContextOptions options, IHttpContextAccessor accessor) : base(options)
        {
            _accessor = accessor;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMethodInfo = modelBuilder.GetType().GetMethod("Entity", new Type[] { });
            var entityType = typeof(IBaseEntity);
            var mapType = typeof(IDbTypeMap);
            Assembly asseService = Assembly.Load("MyBlog.Entity");
            Assembly unitOfWorkService = Assembly.Load("MyBlog.UnitOfWork");
            var entityTypeBuilders = asseService.GetTypes().Where(t => entityType.IsAssignableFrom(t) && t != entityType).ToDictionary(o => o,
                o => entityMethodInfo.MakeGenericMethod(o).Invoke(modelBuilder, null));
            var mapTypes = unitOfWorkService.GetTypes().Where(t => mapType.IsAssignableFrom(t) && t != mapType);
            foreach (var map in mapTypes)
            {
                if (MapTypeFilter(map))
                {
                    dynamic mapInstance = _accessor.HttpContext.RequestServices.GetService(map); //  Dependency.Instance.Container.ResolveOptional(mapType);
                    if (mapInstance != null)
                    {
                        Type type = null;
                        if ((type = map.GetInterface("IEntityDbTypeMap`1")) != null)
                        {
                            var entity = type.GenericTypeArguments.First();
                            if (!entityTypeBuilders.TryGetValue(entity, out dynamic builder))
                            {
                                var methodInfo = entityMethodInfo.MakeGenericMethod(entityType);
                                builder = methodInfo.Invoke(modelBuilder, null);
                            }
                            mapInstance.EntityDbTypeMapping(builder);
                        }
                    }
                }
            }
        }

        protected virtual bool MapTypeFilter(Type type)
        {
            return true;
        }
    }
}
