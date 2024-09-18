using Admin.Erp.Infrastructure.Cache.Interfaces;
using Admin.Erp.Infrastructure.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Admin.Erp.Infrastructure.Cache.Service;

public class CachedService<T> : ICachedService<T> where T : class
{
    private readonly IDistributedCache _distributedCache;
    private readonly DistributedCacheEntryOptions _options;

    public CachedService(IDistributedCache distributedCache)
    {
        _options = new DistributedCacheEntryOptions()
                      .SetAbsoluteExpiration(TimeSpan.FromMinutes(DistributedCacheEntryOptionsGlobal.AbsolutExpiration))
                      .SetSlidingExpiration(TimeSpan.FromMinutes(DistributedCacheEntryOptionsGlobal.SlidingExpiration));

        _distributedCache = distributedCache;
    }

    public async Task<T?> GetItemAsync(string key)
    {
        Valid(key);
        var value = await _distributedCache.GetStringAsync(GetNewKey(key));
        return value is null ? null : JsonSerializer.Deserialize<T>(value, JsonOptionsGlobal.Options);
    }

    public async Task<IList<T>?> GetListItemAsync(string key)
    {
        Valid(key);
        var values = await _distributedCache.GetStringAsync(GetNewKey(key));
        return values is null ? null : JsonSerializer.Deserialize<List<T>>(values, JsonOptionsGlobal.Options);
    }

    public async Task RemoveCachedAsync(string key)
    {
        Valid(key);
        await _distributedCache.RemoveAsync(GetNewKey(key));
    }

    public async Task SetItemAsync(string key, T item)
    {
        Valid(key);
        var valueJson = JsonSerializer.Serialize<T>(item, options: JsonOptionsGlobal.Options);
        await _distributedCache.SetStringAsync(GetNewKey(key), valueJson, _options);
    }

    public async Task SetListItemAsync(string key, IList<T> itens)
    {
        Valid(key);
        var valuesJson = JsonSerializer.Serialize<IList<T>>(itens, options: JsonOptionsGlobal.Options);
        await _distributedCache.SetStringAsync(GetNewKey(key), valuesJson, _options);
    }

    private static void Valid(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new Exception("Key do cached inválida!");
    }

    private string GetNewKey(string key)
    {
        //return $"{_keyParceiro}-{key}";
        return $"{key}";
    }
}
