using MediatR;
using Presupuestos.Application.Abstractions.Email;
using Presupuestos.Domain.Entities.Actividades.Events;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;

internal sealed class CrearActividadDomainEventHandler : INotificationHandler<ActividadCreateDomainEvent>
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IEmailService _emailService;

    public CrearActividadDomainEventHandler(IActividadRepository actividadRepository, IEmailService emailService)
    {
        _actividadRepository = actividadRepository;
        _emailService = emailService;
    }

    public async Task Handle(ActividadCreateDomainEvent notification, CancellationToken cancellationToken)
    {
        var actividad = await _actividadRepository.GetByIdAsync(notification.ActividadId);

        if (actividad is null)
        {
            return;
        }

        await _emailService.SendAsnyc(
            "leontitojosecarlos@gmail.com",
            "Registro de actividad",
            $"Usuario {actividad.Nombre} ha registrado la actividad {actividad.Id}"
        );

    }
}