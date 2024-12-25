using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividad;

internal sealed class GetActividadQueryHandler : IQueryHandler<GetActividadQuery, ActividadResponse>
{
    private readonly IActividadRepository _actividadRepository;

    public GetActividadQueryHandler(IActividadRepository actividadRepository)
    {
        _actividadRepository = actividadRepository;
    }

    public async Task<Result<ActividadResponse>> Handle(GetActividadQuery request, CancellationToken cancellationToken)
    {
        var actividadResult = await _actividadRepository.GetByIdAsync(request.ActividadId, cancellationToken);
        if (actividadResult == null)
        {
            return Result.Failure<ActividadResponse>(ActividadErrors.NotFound);
        }
        
        return Result.Success(new ActividadResponse(
            actividadResult.Id,
            actividadResult.Nombre,
            actividadResult.FechaInicio,
            actividadResult.FechaFin,
            actividadResult.Empleado,
            actividadResult.Estado == ActividadEstado.Activo ? 1 : 0,
            actividadResult.Presupuesto,
            actividadResult.MacroProcesoId,
            actividadResult.ProcesoId,
            actividadResult.SubProcesoId,
            actividadResult.Objetivo,
            actividadResult.Ubicacion
        ));
    }
}