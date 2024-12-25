using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Entities.MacroProcesos;

public class MacroProceso : Entity
{
    public MacroProceso(
          Guid id
        , string nombre
        ) : base(id)
    {
        Nombre = nombre;
    }
    public string Nombre { get; set; } = null!;
}