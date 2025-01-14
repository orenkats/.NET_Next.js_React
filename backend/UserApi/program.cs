using UserApi.Infrastructure.Configurations;
using Microsoft.OpenApi.Models;
using UserApi.Data;
using UserApi.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Configure database connection
builder.Services.AddDbConfiguration(builder.Configuration);
// Add services to the container
builder.Services.AddControllers();

builder.Services.AddApplicationServices();

// Add HttpClient for external API calls
builder.Services.AddHttpClient();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "User API",
        Version = "v1",
        Description = "API to manage users and fetch data from the Random User Generator API."
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use custom middleware for error handling and logging
app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
