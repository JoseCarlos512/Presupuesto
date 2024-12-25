using Presupuestos.Application.Abstractions.Messaging;

namespace Presupuestos.Application.Modules.Actividades.Commands.EliminarActividad;

public sealed record EliminarActividadCommand(
    Guid Id
) : ICommand;