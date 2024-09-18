﻿using Admin.Erp.Domain.Entities;

namespace Admin.Erp.Domain.Interfaces;

public interface IAmbienteDesenvolvimentoRepository
{
    Task RodarMigrationAsync();
    Task AddEmpresaAsync(Empresa empresa);
    Task AddUsuarioAsync(Usuario usuario);
    Task<Empresa?> GetEmpresaDevAsync(string nome);
}
