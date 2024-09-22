using Admin.Erp.Application.Interfaces;
using Admin.Erp.Application.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admin.Erp.Application.Services;

public sealed class JwtService : IJwtService
{
    public string GerarJwtUsuario(UsuarioViewModel usuarioViewModel)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(ConfiguracaoDeToken.Key));

        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
          issuer: ConfiguracaoDeToken.Issue,
          audience: ConfiguracaoDeToken.Audience,
          claims: GenerateClaims(usuarioViewModel),
          expires: DateTime.Now.AddHours(ConfiguracaoDeToken.Expiration),
          signingCredentials: credenciais);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static Claim[] GenerateClaims(object obj)
    {
        var claims = new List<Claim>();

        foreach (var property in obj.GetType().GetProperties())
        {
            var value = property.GetValue(obj);
            if (value != null)
                claims.Add(new Claim(property.Name, value.ToString() ?? "Sem Valor"));

        }

        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        return [.. claims];
    }
}
