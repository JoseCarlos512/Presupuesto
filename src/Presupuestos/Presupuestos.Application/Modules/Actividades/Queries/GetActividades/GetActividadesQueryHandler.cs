using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;
using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividades;

public class GetActividadesQueryHandler : IQueryHandler<GetActividadesQuery, List<ActividadResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetActividadesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public Task<Result<List<ActividadResponse>>> Handle(GetActividadesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}