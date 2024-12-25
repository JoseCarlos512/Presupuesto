using Microsoft.EntityFrameworkCore;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Infrastructure.Repositories;

internal sealed class ActividadRepository : Repository<Actividad>, IActividadRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ApplicationDbContext _dbContext;
    
    public ActividadRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    // public override void Delete(Actividad actividad)
    // {
    //     actividad.IsDeleted = true; // Marcado como eliminado
    //     Update(actividad);          // Usa el método Update del repositorio base
    // }
}