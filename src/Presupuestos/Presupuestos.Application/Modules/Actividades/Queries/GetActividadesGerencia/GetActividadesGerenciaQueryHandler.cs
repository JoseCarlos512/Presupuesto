using System.Data;
using Dapper;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;
using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividadesGerencia;

public sealed class GetActividadesGerenciaQueryHandler:IQueryHandler<GetActividadesGerenciaQuery, List<GerenciaResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetActividadesGerenciaQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<List<GerenciaResponse>>> Handle(GetActividadesGerenciaQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var parametros = new { p_usercode = request.Usercode};
        var encargados = await connection.QueryAsync<GerenciaResponse>(
            "xtus_presupuesto_get_gerencia",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        return Result<List<GerenciaResponse>>.Success(encargados.ToList());
    }
}