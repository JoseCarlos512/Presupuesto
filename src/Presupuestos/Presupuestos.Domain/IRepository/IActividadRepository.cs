using Presupuestos.Domain.Entities.Actividades;

namespace Presupuestos.Domain.IRepository;

public interface IActividadRepository
{
    void Add(Actividad actividad);
    void Update(Actividad actividad);
    void Delete(Actividad actividad);
    Task<Actividad?> GetByIdAsync(Guid actividad, CancellationToken cancellationToken= default);
    Task<List<Actividad>> GetAllAsync(CancellationToken cancellationToken = default);

}