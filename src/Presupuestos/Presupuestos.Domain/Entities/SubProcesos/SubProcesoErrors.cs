using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Entities.SubProcesos;

public static class SubProcesoErrors
{
    public static Error NotFound = new(
        "SubProceso.NotFound",
        "No existe un SubProceso con este id"
    );
}