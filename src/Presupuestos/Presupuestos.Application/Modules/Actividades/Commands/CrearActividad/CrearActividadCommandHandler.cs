using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.Entities.MacroProcesos;
using Presupuestos.Domain.Entities.Procesos;
using Presupuestos.Domain.Entities.SubProcesos;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;

internal sealed class CrearActividadCommandHandler:
    ICommandHandler<CrearActividadCommand, Guid>
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IMacroProcesoRepository _macroProcesoRepository;
    private readonly IProcesoRepository _procesoRepository;
    private readonly ISubProcesoRepository _subProcesoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearActividadCommandHandler(
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

    public async Task<Result<Guid>> Handle(CrearActividadCommand request, CancellationToken cancellationToken)
    {
        var macroProceso = await _macroProcesoRepository.GetByIdAsync(request.id_macro_proceso, cancellationToken);

        if (macroProceso is null)
        {
            return Result.Failure<Guid>(MacroProcesoErrors.NotFound);
        }
        var proceso = await _procesoRepository.GetByIdAsync(request.id_proceso, cancellationToken);

        if (proceso is null)
        {
            return Result.Failure<Guid>(ProcesoErrors.NotFound);
        }
        
        var subproceso = await _subProcesoRepository.GetByIdAsync(request.id_subproceso, cancellationToken);

        if (subproceso is null)
        {
            return Result.Failure<Guid>(SubProcesoErrors.NotFound);
        }
        
        var actividad = Actividad.Create(
            request.nombre
            ,request.fecha_inicio
            ,request.fecha_fin
            ,request.empleado
            ,request.presupuesto
            ,macroProceso.Id
            ,proceso.Id
            ,subproceso.Id
            ,request.objetivo
            ,request.ubicacion
        );
        
        _actividadRepository.Add(actividad);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return actividad.Id;
    }

    internal static CrearActividadCommandHandler CreateInternal(
        IActividadRepository actividadRepository, 
        IMacroProcesoRepository macroProcesoRepository, 
        IProcesoRepository procesoRepository, 
        ISubProcesoRepository subProcesoRepository,
        IUnitOfWork unitOfWork)
    {
        return new CrearActividadCommandHandler(
            actividadRepository, 
            macroProcesoRepository, 
            procesoRepository, 
            subProcesoRepository,
            unitOfWork
        );
    }
}