using FluentValidation;
using FluentValidation.AspNetCore;
using GarageInventory.Core.Services;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Core.Validators.Users;
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
            return services;
        }

        private static IServiceCollection RegisterDtoValidators(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserValidator>();

            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}