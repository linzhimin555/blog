using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyBlog.Core
{
    public static class Bootstrap
    {
        public static IServiceCollection InitBaseService(this IServiceCollection services)
        {
            //var interfaceRepository = typeof(IRepository);
            //Assembly asseRepository = Assembly.Load("MyBlog.Repository");
            //var lsRepository = asseRepository.GetTypes()
            //        .Where(t => interfaceRepository.IsAssignableFrom(t) && t != interfaceRepository).ToList();
            //foreach (Type type in lsRepository)
            //{
            //    services.AddScoped(type);


            Assembly asseService = Assembly.Load("MyBlog.Service");
            var serviceType = typeof(IService);
            var serviceTypes = asseService.GetTypes()
                    .Where(t => serviceType.IsAssignableFrom(t) && t != serviceType).ToList();
            foreach (Type type in serviceTypes)
            {
                var interType = type.GetInterfaces()[1];
                services.AddScoped(interType, type);
            }

            Assembly asseUnitOfWork = Assembly.Load("MyBlog.UnitOfWork");
            var mapType = typeof(IDbTypeMap);
            var mapTypes = asseUnitOfWork.GetTypes()
                    .Where(t => mapType.IsAssignableFrom(t) && t != mapType).ToList();
            foreach (Type type in mapTypes)
            {
                services.AddSingleton(type);
            }

            return services;
        }
    }
}
