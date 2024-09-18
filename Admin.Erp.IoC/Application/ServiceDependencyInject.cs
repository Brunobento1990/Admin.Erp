using Admin.Erp.Application.Interfaces;
using Admin.Erp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Erp.IoC.Application;

public static class ServiceDependencyInject
{
    public static IServiceCollection InjectService(this IServiceCollection services)
    {
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IAmbienteDesenvolvimentoService, AmbienteDesenvolvimentoService>();

        return services;
    }
}
