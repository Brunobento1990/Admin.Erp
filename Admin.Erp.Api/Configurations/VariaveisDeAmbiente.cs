﻿namespace Admin.Erp.Api.Configurations;

public class VariaveisDeAmbiente
{
    public static string GetVariavel(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new Exception($"Key inválida : {key}");

        return Environment.GetEnvironmentVariable(key) ??
            throw new Exception($"Variável não encontrada com a Key : {key}");
    }

    public static bool IsDevelopment()
    {
        return Environment.GetEnvironmentVariable("AMBIENTE") == "develop";
    }
}
