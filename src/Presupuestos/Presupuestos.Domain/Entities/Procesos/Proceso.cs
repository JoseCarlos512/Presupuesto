using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.MacroProcesos;

namespace Presupuestos.Domain.Entities.Procesos;

public class Proceso : Entity
{
    public Proceso(
          Guid id
        , string nombre
        , Guid macroProcesoId
        ) : base(id)
    {
        Nombre = nombre;
        MacroProcesoId = macroProcesoId;
    }

    public string? Nombre { get; set; } = null!;
    
    // Foreign Key hacia MacroProceso
    public Guid MacroProcesoId { get; set; }
    public MacroProceso? MacroProceso { get; set; }
}