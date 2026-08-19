using GarageInventory.Core.Configuration;
using GarageInventory.Core.Services;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Configuration;
using GarageInventory.Persistence.Database.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
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
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Database initialization for development environments
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    var connectionString = app.Configuration.GetConnectionString("SQLiteConnection");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string 'SQLiteConnection' is not defined.");
    }

    var initializer =
        scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

    await initializer.InitializeDatabaseAsync(connectionString);
}


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowCookieAuth");

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapControllers();

app.Run();
