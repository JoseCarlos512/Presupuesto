using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividadesPresupuesto;

public sealed record GetActividadesPresupuestoQuery(string UserCode):IQuery<List<PresupuestoResponse>>;