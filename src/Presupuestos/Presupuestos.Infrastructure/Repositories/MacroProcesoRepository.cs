using Presupuestos.Domain.Entities.MacroProcesos;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Infrastructure.Repositories;

internal sealed class MacroProcesoRepository : Repository<MacroProceso>, IMacroProcesoRepository
{
    public MacroProcesoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}