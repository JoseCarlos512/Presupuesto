using System.Data;
using Dapper;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;
using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividadesPresupuesto;

public sealed class GetActividadesPresupuestoQueryHandler:IQueryHandler<GetActividadesPresupuestoQuery, List<PresupuestoResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetActividadesPresupuestoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<List<PresupuestoResponse>>> Handle(GetActividadesPresupuestoQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var parametros = new { p_usercode = request.UserCode };
        var presupuestos = await connection.QueryAsync<PresupuestoResponse>(
            "xtus_presupuesto_actividad_get_presupuesto",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        return Result<List<PresupuestoResponse>>.Success(presupuestos.ToList());
    }
}