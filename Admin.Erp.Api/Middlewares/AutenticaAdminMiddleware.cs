using Admin.Erp.Api.Attributes;
using Admin.Erp.Domain.Exceptions;
using Admin.Erp.Domain.Interfaces;
using Microsoft.AspNetCore.Http.Features;

namespace Admin.Erp.Api.Middlewares;

public class AutenticaAdminMiddleware
{
    private readonly RequestDelegate _next;
    public AutenticaAdminMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext httpContext,
        IEmpresaAutenticada empresaAutenticada,
        IEmpresaRepository empresaRepository,
        IUsuarioAutenticado usuarioAutenticado)
    {

        var autenticar = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata
                .FirstOrDefault(m => m is AutenticaAdminAttribute) is AutenticaAdminAttribute;

        if (!autenticar)
        {
            await _next(httpContext);
            return;
        }

        var empresa = await empresaRepository.GetByIdAsync(usuarioAutenticado.EmpresaId)
            ?? throw new ExceptionApiUnauthorized("Não foi possível localizar o cadastro da sua empresa");

        empresaAutenticada.Premium = empresa.Premium;
        empresaAutenticada.Id = empresa.Id;

        await _next(httpContext);
    }
}
