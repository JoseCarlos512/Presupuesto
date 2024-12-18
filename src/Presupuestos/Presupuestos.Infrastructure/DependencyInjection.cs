using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presupuestos.Application.Abstractions.Clock;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Email;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Infrastructure;
using Presupuestos.Infrastructure.Clock;
using Presupuestos.Infrastructure.Data;
using Presupuestos.Infrastructure.Email;

// using Presupuestos.Domain.Roles;
// using Presupuestos.Domain.Usuarios;
// using Presupuestos.Infrastructure.Clock;
// using Presupuestos.Infrastructure.Data;
// using Presupuestos.Infrastructure.Email;
// using Presupuestos.Infrastructure.Repositories;

namespace Usuarios.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddTransient<IDateTimeProvider,DateTimeProvider>();
        services.AddTransient<IEmailService,EmailServices>();

        var connectionString = configuration.GetConnectionString("Database")
        ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(
            options => {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention(); // usuario, producto_detalle
            }
        );

        // services.AddScoped<IUsuarioRepository,UsuarioRepository>();
        // services.AddScoped<IRolRepository, RolRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        
        return services;
    }
}
