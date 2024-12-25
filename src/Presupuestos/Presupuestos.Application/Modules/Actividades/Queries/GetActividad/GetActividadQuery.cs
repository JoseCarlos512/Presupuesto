using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividad;

public sealed record GetActividadQuery(Guid ActividadId): IQuery<ActividadResponse>;