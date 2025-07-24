using StackExchange.Redis;
using System.Text.Json;
using RedisApiDemo.Models;

namespace RedisApiDemo.Services;

public class RedisService
{
    private readonly IDatabase _db;

    public RedisService(IConfiguration config)
    {
        var redis = ConnectionMultiplexer.Connect(config.GetConnectionString("Redis"));
        _db = redis.GetDatabase();
    }

    public async Task<Project?> GetProjectAsync(string key)
    {
        var value = await _db.StringGetAsync(key);
        return value.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Project>(value!);
    }
}
