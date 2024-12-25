using Presupuestos.Domain.Entities.SubProcesos;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Infrastructure.Repositories;

internal sealed class SubProcesoRepository: Repository<SubProceso>, ISubProcesoRepository
{
    public SubProcesoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}