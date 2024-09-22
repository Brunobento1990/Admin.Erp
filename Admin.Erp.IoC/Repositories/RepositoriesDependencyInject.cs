using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Cached.Cached;
using Admin.Erp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Erp.IoC.Repositories;

public static class RepositoriesDependencyInject
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<MenuRepository>();
        services.AddScoped<IMenuRepository, MenuCached>();
        services.AddScoped<IAmbienteDesenvolvimentoRepository, AmbienteDesenvolvimentoRepository>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>();

        return services;
    }
}
