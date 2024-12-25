using Presupuestos.Domain.Entities.Procesos;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Infrastructure.Repositories;

internal sealed class ProcesoRepository : Repository<Proceso>, IProcesoRepository
{
    public ProcesoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}