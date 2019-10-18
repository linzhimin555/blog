using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core
{
    public static class UnitOfWorkExtension
    {
        public static IServiceCollection AddUnitOfWork<TService, TUnitOfWork>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null) where TService : class where TUnitOfWork : UnitOfWorkBase, TService
        {
            services.AddDbContext<TUnitOfWork>(optionsAction);
            services.AddScoped<TService, TUnitOfWork>();
            return services;
        }
    }
}
