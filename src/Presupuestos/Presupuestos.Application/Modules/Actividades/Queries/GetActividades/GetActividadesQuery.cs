using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividades;

public sealed record GetActividadesQuery(): IQuery<List<ActividadResponse>>;