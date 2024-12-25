namespace Presupuestos.Api.Controllers.Request;

public record ActividadRequest(
  string nombre,
  DateTime fecha_inicio,  
  DateTime fecha_fin,
  string empleado,
  string? ubicacion,
  string? presupuesto,
  Guid id_macro_proceso, 
  Guid id_proceso,
  Guid id_subproceso,  
  string? objetivo 
);