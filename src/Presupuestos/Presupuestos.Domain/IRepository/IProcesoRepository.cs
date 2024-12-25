using Presupuestos.Domain.Entities.Procesos;

namespace Presupuestos.Domain.IRepository;

public interface IProcesoRepository
{
    Task<Proceso?> GetByIdAsync(Guid ProcesoId, CancellationToken cancellationToken= default);
}