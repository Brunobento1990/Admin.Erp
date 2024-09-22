using Admin.Erp.Application.Interfaces;
using Admin.Erp.Domain.Entities;
using Admin.Erp.Domain.Interfaces;

namespace Admin.Erp.Application.Services;

public sealed class AmbienteDesenvolvimentoService : IAmbienteDesenvolvimentoService
{
    private readonly IAmbienteDesenvolvimentoRepository _ambienteDesenvolvimentoRepository;

    public AmbienteDesenvolvimentoService(IAmbienteDesenvolvimentoRepository ambienteDesenvolvimentoRepository)
    {
        _ambienteDesenvolvimentoRepository = ambienteDesenvolvimentoRepository;
    }

    public async Task IniciarAsync()
    {
        await _ambienteDesenvolvimentoRepository.RodarMigrationAsync();
        var nomeDaEmpresa = "Desenvolvimento";
        var empresa = await _ambienteDesenvolvimentoRepository.GetEmpresaDevAsync(nome: nomeDaEmpresa);
        if (empresa != null)
        {
            return;
        }
        var data = DateTime.Now;
        empresa = new Empresa(
            id: Guid.CreateVersion7(),
            criadoEm: data,
            atualizadoEm: data,
            razaoSocial: nomeDaEmpresa,
            nomeFantasia: nomeDaEmpresa,
            cnpj: "123",
            premium: true);

        await _ambienteDesenvolvimentoRepository.AddEmpresaAsync(empresa);

        var perfil = PerfilUsuario.NovoPerfil(descricao: "dev perfil", empresa.Id);
        await _ambienteDesenvolvimentoRepository.AddPerfilAsync(perfil);

        var usuario = Usuario.NovoUsuario(
            empresaId: empresa.Id,
            nome: "dev",
            cpf: "00000000",
            dataDeNascimento: null,
            senha: "$2a$10$NqR07ERdl.v32pQJJemrXu45nPMcZnY9WvaGX1winoU5vnOYVjoRG",
            perfilUsuarioId: perfil.Id);

        usuario.AcessoUsuario = new AcessoUsuario(
            id: Guid.CreateVersion7(),
            criadoEm: data,
            atualizadoEm: data,
            bloqueado: false,
            tokenEsqueceuSenha: null,
            expiracaoDoTokenEsqueceuSenha: null,
            usuarioId: usuario.Id,
            email: "dev@gmail.com");

        await _ambienteDesenvolvimentoRepository.AddUsuarioAsync(usuario);
    }
}
