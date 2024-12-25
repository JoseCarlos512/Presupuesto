using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividadesEncargado;

public sealed record GetActividadesEncargadoQuery(string Usercode) : IQuery<List<EncargadoResponse>>;