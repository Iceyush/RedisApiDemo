using RedisApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Redis connection string directly
builder.Configuration["ConnectionStrings:Redis"] = "localhost:6379";

// Register RedisService
builder.Services.AddSingleton<RedisService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();
