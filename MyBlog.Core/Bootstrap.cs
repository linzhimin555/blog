using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyBlog.Core
{
    public static class Bootstrap
    {
        public static IServiceCollection InitBaseSeervice(this IServiceCollection services)
        {
            var interfaceRepository = typeof(IRepository);
            Assembly asseRepository = Assembly.Load("MyBlog.Repository");
            var lsRepository = asseRepository.GetTypes()
                    .Where(t => interfaceRepository.IsAssignableFrom(t) && t != interfaceRepository).ToList();
            foreach (Type type in lsRepository)
            {
                services.AddScoped(type);
            }

            var interfaceService = typeof(IService);
            Assembly asseService= Assembly.Load("MyBlog.Service");
            var lsService = asseService.GetTypes()
                    .Where(t => interfaceService.IsAssignableFrom(t) && t != interfaceService).ToList();
            foreach (Type type in lsService)
            {
                services.AddScoped(type);
            }

            return services;
        }
    }
}
