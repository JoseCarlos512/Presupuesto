using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presupuestos.Application.Abstractions.Clock;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Email;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.IRepository;
using Presupuestos.Infrastructure;
using Presupuestos.Infrastructure.Clock;
using Presupuestos.Infrastructure.Data;
using Presupuestos.Infrastructure.Email;
using Presupuestos.Infrastructure.Repositories;

// using Presupuestos.Domain.Roles;
// using Presupuestos.Domain.Usuarios;
// using Presupuestos.Infrastructure.Clock;
// using Presupuestos.Infrastructure.Data;
// using Presupuestos.Infrastructure.Email;
// using Presupuestos.Infrastructure.Repositories;

namespace Presupuestos.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        
        // Cargar la configuración de EmailSettings directamente
        var emailSettings = new EmailSettings();
        configuration.GetSection("EmailSettings").Bind(emailSettings);

        // Registrar EmailSettings en el contenedor de servicios
        services.AddSingleton(emailSettings);
        
        services.AddTransient<IDateTimeProvider,DateTimeProvider>();
        services.AddTransient<IEmailService,EmailServices>();

        var connectionString = configuration.GetConnectionString("Database")
        ?? throw new ArgumentNullException(nameof(configuration));

        // services.AddDbContext<ApplicationDbContext>(
        //     options => {
        //         options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention(); // usuario, producto_detalle
        //     }
        // );
        
        // Cambiado para usar SQL Server
        services.AddDbContext<ApplicationDbContext>(
            options => {
                options.UseSqlServer(connectionString); // Cambiado para SQL Server
            }
        );

        // services.AddScoped<IUsuarioRepository,UsuarioRepository>();
        // services.AddScoped<IRolRepository, RolRepository>();
        
        

        services.AddScoped<IActividadRepository,ActividadRepository>();
        services.AddScoped<IMacroProcesoRepository,MacroProcesoRepository>();
        services.AddScoped<IProcesoRepository,ProcesoRepository>();
        services.AddScoped<ISubProcesoRepository,SubProcesoRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        
        return services;
    }
}
