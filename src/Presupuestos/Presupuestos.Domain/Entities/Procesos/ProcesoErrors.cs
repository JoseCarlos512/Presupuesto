using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Entities.Procesos;

public static class ProcesoErrors
{
    public static Error NotFound = new(
        "Proceso.NotFound",
        "No existe un Proceso con este id"
    );
}