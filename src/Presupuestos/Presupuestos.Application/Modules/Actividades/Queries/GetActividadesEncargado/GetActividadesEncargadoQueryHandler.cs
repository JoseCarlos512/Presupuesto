using System.Data;
using Dapper;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;
using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividadesEncargado;

internal sealed class GetActividadesEncargadoQueryHandler : IQueryHandler<GetActividadesEncargadoQuery, List<EncargadoResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetActividadesEncargadoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<List<EncargadoResponse>>> Handle(GetActividadesEncargadoQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var parametros = new { p_usercode = request.Usercode};
        var encargados = await connection.QueryAsync<EncargadoResponse>(
            "xtus_presupuesto_actividad_get_encargados",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        return Result<List<EncargadoResponse>>.Success(encargados.ToList());
    }
}