using GarageInventory.Core.Configuration;
using GarageInventory.Persistence.Configuration;
using GarageInventory.Persistence.Database.Interfaces;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Garage Inventory API",
        Version = "v1"
    });
});
builder.Services.RegisterCore(builder.Configuration);
builder.Services.RegisterPersistence(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCookieAuth", policy =>
    {
        policy.WithOrigins("https://localhost:3000", "https://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});


builder.Services
    .AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.None;
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(1);

        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Garage Inventory API v1");
    });

    using var scope = app.Services.CreateScope();

    // Database initialization for development environments
    var connectionString = app.Configuration.GetConnectionString("SQLiteConnection");

    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("Connection string 'SQLiteConnection' is not defined.");

    // Extract database file path from connection string
    var dbFilePath = ExtractDatabaseFilePath(connectionString);

    // Only initialize database if it doesn't exist
    if (!File.Exists(dbFilePath))
    {
        var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
        await initializer.InitializeDatabaseAsync(connectionString);
    }
}

app.UseHttpsRedirection();
app.UseCors("AllowCookieAuth");
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();

app.Run();

static string ExtractDatabaseFilePath(string connectionString)
{
    var parts = connectionString.Split(';');
    foreach (var part in parts)
    {
        if (part.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
        {
            return part.Substring("Data Source=".Length).Trim();
        }
    }
    throw new InvalidOperationException("Could not extract database file path from connection string.");
}
