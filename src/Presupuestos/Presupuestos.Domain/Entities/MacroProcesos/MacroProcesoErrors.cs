using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Entities.MacroProcesos;

public static class MacroProcesoErrors
{
    public static Error NotFound = new(
        "MacroProceso.NotFound",
        "No existe un MacroProceso con este id"
    );
}