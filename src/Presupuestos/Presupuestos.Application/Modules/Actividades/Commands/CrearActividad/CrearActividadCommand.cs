using Presupuestos.Application.Abstractions.Messaging;

namespace Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;

public record CrearActividadCommand(
     string nombre,
     DateTime fecha_inicio,  
     DateTime fecha_fin,
     string empleado,
     string? presupuesto,
     Guid id_macro_proceso,
     Guid id_proceso,
     Guid id_subproceso,  
     string? objetivo,
     string? ubicacion
) : ICommand<Guid>;