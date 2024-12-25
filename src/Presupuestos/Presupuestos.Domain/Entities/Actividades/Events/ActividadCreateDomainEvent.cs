using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Entities.Actividades.Events;

public sealed record class ActividadCreateDomainEvent(Guid ActividadId) : IDomainEvent;