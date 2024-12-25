namespace Presupuestos.Application.Modules.Actividades.Response;

public sealed record ActividadResponse
(
      Guid id
    , string nombre
    , DateTime fechaInicio
    , DateTime fechaFin
    , string empleado
    , int estado
    , string? presupuesto
    , Guid? macroProcesoId
    , Guid? procesoId
    , Guid? subProcesoId
    , string? objetivo
    , string? ubicacion
);
