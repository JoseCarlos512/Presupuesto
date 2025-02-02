using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Presupuestos.Application.Abstractions.Behaviors;
// using Presupuestos.Domain.Presupuestos;

namespace Presupuestos.Application;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
               configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
               configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
               configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            // services.AddTransient<NombreUsuarioService>();

            return services;
        }
    }
