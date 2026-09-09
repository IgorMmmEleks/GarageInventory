using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Database;
using GarageInventory.Persistence.Database.Interfaces;
using GarageInventory.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GarageInventory.Persistence.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLiteConnection");

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'SQLiteConnection' is not defined.");
            }

            services.AddSingleton<IDbConnectionFactory>(
                   new SqliteConnectionFactory(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IManufactureRepository, ManufactureRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IToolSetRepository, ToolSetRepository>();

            return services;
        }
    }
}
