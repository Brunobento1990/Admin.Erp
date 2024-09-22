using Admin.Erp.Api.Attributes;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Admin.Erp.Domain.Exceptions;

namespace Admin.Erp.Api.Middlewares;

public class AutenticaPerfilUsuarioMiddleware
{
    private readonly RequestDelegate _next;
    public AutenticaPerfilUsuarioMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext httpContext,
        IUsuarioAutenticado usuarioAutenticado,
        AppDbContext appDbContext)
    {
        var autenticar = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata
                .FirstOrDefault(m => m is AutenticaPerfilAttribute) is AutenticaPerfilAttribute;

        if (!autenticar)
        {
            await _next(httpContext);
            return;
        }

        var path = httpContext.Request.Path.ToString();
        //var menu = await appDbContext
        //    .Menus
        //    .AsNoTracking()
        //    .Include(x => x.MenuRotas.Where(y => y.Rota == path))
        //    .FirstOrDefaultAsync(x => x.MenuRotas.Any(y => y.Rota == path));

        var perfil = await appDbContext
            .PerfilUsuarios
            .AsNoTracking()
            .Include(x => x.PerfilUsuarioMenu)
                .ThenInclude(x => x.PerfilUsuarioMenuRota)
            .FirstOrDefaultAsync(x => x.Id == usuarioAutenticado.PerfilUsuarioId)
                ?? throw new ErroApiException("Não foi possível localizar o seu perfil!");

        var rotasIds = perfil
            .PerfilUsuarioMenu
            .FirstOrDefault()?
            .PerfilUsuarioMenuRota
            .Select(x => x.MenuRotaId)
            .ToList() ?? [];

        var permissao = await appDbContext
            .PerfilUsuarioMenuRotas
            .AsNoTracking()
            .Include(x => x.MenuRota)
            .FirstOrDefaultAsync(x => x.MenuRota.Rota == path && rotasIds.Contains(x.MenuRotaId))
                ?? throw new ErroApiException("Você não tem acesso a este recurso do sistema!");

        await _next(httpContext);
    }
}
