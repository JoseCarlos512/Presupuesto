using FluentValidation;
using Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;

namespace Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;

public class CrearActividadCommandValidator : AbstractValidator<CrearActividadCommand>
{
    public CrearActividadCommandValidator()
    {
        RuleFor(c => c.nombre).NotEmpty();
        RuleFor(c => c.ubicacion).NotEmpty();
        RuleFor(c => c.fecha_fin).LessThan(DateTime.UtcNow);
    }
}