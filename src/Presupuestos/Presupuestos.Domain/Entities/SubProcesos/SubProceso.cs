using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Procesos;

namespace Presupuestos.Domain.Entities.SubProcesos;

public class SubProceso : Entity
{
    public SubProceso(
          Guid id
        , string nombre
        , Guid procesoId
        ) : base(id)
    {
        Nombre = nombre;
        ProcesoId = procesoId;
    }

    public string Nombre { get; set; } = null!;
    
    // Foreign Key hacia Proceso
    public Guid ProcesoId { get; set; }
    public Proceso? Proceso { get; set; }
}