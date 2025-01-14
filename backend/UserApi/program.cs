
using UserApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.ConfigureServices(builder.Configuration);

// Build the app
var app = builder.Build();

// Configure middleware
app.ConfigureMiddleware();

app.Run();
