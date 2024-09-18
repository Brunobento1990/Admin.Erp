using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;
using Admin.Erp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Erp.IoC.Context;

public static class ContextDependencyInject
{
    public static IServiceCollection InjectContext(this IServiceCollection services, string connectionString)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<IEmpresaAutenticada, EmpresaAutenticada>();
        services.AddScoped<IUsuarioAutenticado, UsuarioAutenticado>();

        return services;
    }
}
