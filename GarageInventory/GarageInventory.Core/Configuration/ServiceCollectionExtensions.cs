using FluentValidation;
using FluentValidation.AspNetCore;
using GarageInventory.Core.Services;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Core.Validators.Tools;
using GarageInventory.Core.Validators.Users;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GarageInventory.Core.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDtoValidators(services, configuration);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();

            services.AddScoped(serviceProvider => new Lazy<IItemGroupRepository>(serviceProvider.GetRequiredService<IItemGroupRepository>));
            services.AddScoped(serviceProvider => new Lazy<IItemFotoRepository>(serviceProvider.GetRequiredService<IItemFotoRepository>));
            services.AddScoped(serviceProvider => new Lazy<IManufactureRepository>(serviceProvider.GetRequiredService<IManufactureRepository>));
            services.AddScoped(serviceProvider => new Lazy<IToolRepository>(serviceProvider.GetRequiredService<IToolRepository>));
            services.AddScoped(serviceProvider => new Lazy<IToolSetRepository>(serviceProvider.GetRequiredService<IToolSetRepository>));

            //TODO may be can be removed
            services.AddScoped<IItemsService, ItemsService>();

            return services;
        }

        private static IServiceCollection RegisterDtoValidators(this IServiceCollection services, IConfiguration configuration)
        {
            //User validators
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserValidator>();

            //Tool validators
            services.AddValidatorsFromAssemblyContaining<CreateToolItemValidator>();

            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}