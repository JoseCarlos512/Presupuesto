using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividadesGerencia;

public sealed record GetActividadesGerenciaQuery(string Usercode):IQuery<List<GerenciaResponse>>;