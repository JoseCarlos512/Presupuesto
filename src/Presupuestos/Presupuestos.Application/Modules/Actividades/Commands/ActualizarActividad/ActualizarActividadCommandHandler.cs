using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.Entities.MacroProcesos;
using Presupuestos.Domain.Entities.Procesos;
using Presupuestos.Domain.Entities.SubProcesos;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Modules.Actividades.Commands.ActualizarActividad;

internal sealed class ActualizarActividadCommandHandler:
    ICommandHandler<ActualizarActividadCommand>
{
    
    private readonly IActividadRepository _actividadRepository;
    private readonly IMacroProcesoRepository _macroProcesoRepository;
    private readonly IProcesoRepository _procesoRepository;
    private readonly ISubProcesoRepository _subProcesoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActualizarActividadCommandHandler(
        IActividadRepository actividadRepository, 
        IMacroProcesoRepository macroProcesoRepository, 
        IProcesoRepository procesoRepository, 
        ISubProcesoRepository subProcesoRepository, 
        IUnitOfWork unitOfWork
    )
    {
        _actividadRepository = actividadRepository;
        _macroProcesoRepository = macroProcesoRepository;
        _procesoRepository = procesoRepository;
        _subProcesoRepository = subProcesoRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(ActualizarActividadCommand request, CancellationToken cancellationToken)
    {
        var actividad = await _actividadRepository.GetByIdAsync(request.id, cancellationToken);

        if (actividad is null)
        {
            return Result.Failure(ActividadErrors.NotFound);
        }

        var macroProceso = await _macroProcesoRepository.GetByIdAsync(request.id_macro_proceso, cancellationToken);
        if (macroProceso is null) return Result.Failure(MacroProcesoErrors.NotFound);

        var proceso = await _procesoRepository.GetByIdAsync(request.id_proceso, cancellationToken);
        if (proceso is null) return Result.Failure(ProcesoErrors.NotFound);

        var subProceso = await _subProcesoRepository.GetByIdAsync(request.id_subproceso, cancellationToken);
        if (subProceso is null) return Result.Failure(SubProcesoErrors.NotFound);
        
        actividad.Update(
            request.nombre,
            request.fecha_inicio,
            request.fecha_fin,
            request.empleado,
            request.presupuesto,
            macroProceso.Id,
            proceso.Id,
            subProceso.Id,
            request.objetivo,
            request.ubicacion
        );
        
        // Guardar cambios
        _actividadRepository.Update(actividad);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}