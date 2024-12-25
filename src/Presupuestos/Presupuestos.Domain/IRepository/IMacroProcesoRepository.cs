using Presupuestos.Domain.Entities.MacroProcesos;

namespace Presupuestos.Domain.IRepository;

public interface IMacroProcesoRepository
{
    Task<MacroProceso?> GetByIdAsync(Guid MacroProcesoId, CancellationToken cancellationToken= default);
}