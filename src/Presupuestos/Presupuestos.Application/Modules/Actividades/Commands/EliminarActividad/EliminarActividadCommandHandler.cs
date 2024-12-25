using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Modules.Actividades.Commands.EliminarActividad;

public sealed class EliminarActividadCommandHandler : ICommandHandler<EliminarActividadCommand>
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EliminarActividadCommandHandler(IActividadRepository actividadRepository, IUnitOfWork unitOfWork)
    {
        _actividadRepository = actividadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EliminarActividadCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var actividad = await _actividadRepository.GetByIdAsync(request.Id);
            if (actividad is null)
            {
                return Result.Failure(ActividadErrors.NotFound);
            }

            _actividadRepository.Delete(actividad);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            var error = new Error("UnexpectedError", $"Error inesperado: {ex.Message}");
            return Result.Failure(error);
        }
    }
}