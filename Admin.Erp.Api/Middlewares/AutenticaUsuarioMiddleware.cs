using Admin.Erp.Api.Attributes;
using Admin.Erp.Api.Configurations;
using Admin.Erp.Application.ViewModel;
using Admin.Erp.Domain.Exceptions;
using Admin.Erp.Domain.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Admin.Erp.Api.Middlewares;

public class AutenticaUsuarioMiddleware
{
    private readonly RequestDelegate _next;
    public AutenticaUsuarioMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext httpContext,
        IUsuarioAutenticado usuarioAutenticado)
    {
        var autenticar = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata
                .FirstOrDefault(m => m is AutenticaUsuarioAttibute) is AutenticaUsuarioAttibute;

        if (!autenticar)
        {
            await _next(httpContext);
            return;
        }

        var token = httpContext.Request.Headers.Authorization.ToString().Split(" ").Last().Replace("undefined", "")
            ?? throw new ExceptionApiUnauthorized("Por favor, efetue o login novamente");

        var keyJwt = VariaveisDeAmbiente.GetVariavel("JWT_KEY");

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = ConfiguracaoDeToken.Issue,
                ValidAudience = ConfiguracaoDeToken.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfiguracaoDeToken.Key))
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value
                ?? throw new ExceptionApiUnauthorized("Token inválido");
            var empresaId = jwtToken.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value
                ?? throw new ExceptionApiUnauthorized("Token inválido");
            var perfilUsuarioId = jwtToken.Claims.FirstOrDefault(c => c.Type == "PerfilUsuarioId")?.Value
                ?? throw new ExceptionApiUnauthorized("Token inválido");

            if (!Guid.TryParse(id, out Guid idParse) ||
                !Guid.TryParse(empresaId, out Guid empresaIdParse) ||
                !Guid.TryParse(perfilUsuarioId, out Guid perfilUsuarioIdParse))
            {
                throw new ExceptionApiUnauthorized("Por favor, efetue o login novamente");
            }

            usuarioAutenticado.Id = idParse;
            usuarioAutenticado.EmpresaId = empresaIdParse;
            usuarioAutenticado.PerfilUsuarioId = perfilUsuarioIdParse;
        }
        catch (SecurityTokenExpiredException)
        {
            throw new ExceptionApiUnauthorized("Sessão expirada, efetue o login novamente!");
        }
        catch (Exception)
        {
            throw new ExceptionApiUnauthorized("Efetue o login novamente!");
        }

        await _next(httpContext);
    }
}
