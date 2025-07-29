using RedisApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Redis connection string directly
builder.Configuration["ConnectionStrings:Redis"] = "localhost:6379";

// Register RedisService
builder.Services.AddSingleton<RedisService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAngular");

app.MapControllers();
app.Run();
