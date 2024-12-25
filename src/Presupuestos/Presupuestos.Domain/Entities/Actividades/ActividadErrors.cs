using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Entities.Actividades;

public static class ActividadErrors
{
    public static Error NotFound = new(
        "Actividad.NotFound",
        "No existe una Actividad con este id"
    );
}