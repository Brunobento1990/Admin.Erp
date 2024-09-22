using Admin.Erp.Domain.Entities.Bases;
using NpgsqlTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Admin.Erp.Domain.Entities;

public sealed class Usuario : BaseEntityPessoa
{
    public Usuario(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        Guid empresaId,
        string nome,
        string? cpf,
        DateTime? dataDeNascimento,
        string senha,
        Guid perfilUsuarioId)
            : base(id, criadoEm, atualizadoEm, empresaId, nome, cpf, dataDeNascimento)
    {
        Senha = senha;
        PerfilUsuarioId = perfilUsuarioId;
    }
    public AcessoUsuario AcessoUsuario { get; set; } = null!;
    public Guid PerfilUsuarioId { get; private set; }
    public PerfilUsuario PerfilUsuario { get; set; } = null!;
    public string Senha { get; private set; }

    public static Usuario NovoUsuario(
        Guid empresaId,
        string nome,
        string? cpf,
        DateTime? dataDeNascimento,
        string senha,
        Guid perfilUsuarioId)
    {
        return new Usuario(
            id: Guid.CreateVersion7(),
            criadoEm: DateTime.Now,
            atualizadoEm: DateTime.Now,
            empresaId: empresaId,
            nome: nome,
            cpf: cpf,
            dataDeNascimento: dataDeNascimento,
            senha: senha,
            perfilUsuarioId: perfilUsuarioId);
    }
}
