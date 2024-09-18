using System.Text.Json;
using System.Text.Json.Serialization;

namespace Admin.Erp.Infrastructure.Models;

public static class JsonOptionsGlobal
{
    public static JsonSerializerOptions Options
    {
        get => new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
    }
}
