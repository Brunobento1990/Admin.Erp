using Admin.Erp.Infrastructure.Cache.Interfaces;
using Admin.Erp.Infrastructure.Cache.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Erp.IoC.Context;

public static class CacheDependencyInject
{
    public static IServiceCollection InjectCache(this IServiceCollection services, string connectionString, string instanceName)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = connectionString;
            options.InstanceName = instanceName;
        });

        services.AddTransient(typeof(ICachedService<>), typeof(CachedService<>));

        return services;
    }
}
