using FluentValidation;
using Presupuestos.Application.Modules.Actividades.Commands.ActualizarActividad;

namespace Presupuestos.Application.Modules.Actividades.Commands.ActualizarActividad;

public class ActualizarActividadCommandValidator: AbstractValidator<ActualizarActividadCommand>
{
    public ActualizarActividadCommandValidator()
    {
        RuleFor(c => c.nombre).NotEmpty();
        RuleFor(c => c.ubicacion).NotEmpty();
        RuleFor(c => c.fecha_fin).LessThan(DateTime.UtcNow);
    }
}