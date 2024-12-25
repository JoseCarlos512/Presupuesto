using Presupuestos.Domain.Entities.SubProcesos;

namespace Presupuestos.Domain.IRepository;

public interface ISubProcesoRepository
{
    Task<SubProceso?> GetByIdAsync(Guid SubProcesoId, CancellationToken cancellationToken= default);
}