using Microsoft.AspNetCore.Mvc;
using RedisApiDemo.Services;

namespace RedisApiDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly RedisService _redis;

    public ProjectController(RedisService redis)
    {
        _redis = redis;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var project = await _redis.GetProjectAsync("project:1");
        return project is not null ? Ok(project) : NotFound();
    }
}
