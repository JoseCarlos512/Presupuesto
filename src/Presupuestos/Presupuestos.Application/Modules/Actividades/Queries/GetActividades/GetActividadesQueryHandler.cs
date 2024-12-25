using System.Data;
using Dapper;
using Presupuestos.Application.Abstractions.Data;
using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Modules.Actividades.Response;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Modules.Actividades.Queries.GetActividades;

internal sealed class GetActividadesQueryHandler : IQueryHandler<GetActividadesQuery, List<ActividadPersonalizadaResponse>>
{
    private readonly IActividadRepository _actividadRepository;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetActividadesQueryHandler(IActividadRepository actividadRepository, ISqlConnectionFactory sqlConnectionFactory)
    {
        _actividadRepository = actividadRepository;
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<List<ActividadPersonalizadaResponse>>> Handle(GetActividadesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var parametros = new { p_usercode = request.Usercode};
        var actividades = await connection.QueryAsync<ActividadPersonalizadaResponse>(
            "xtus_presupuesto_obtener_actividad",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        return Result<List<ActividadPersonalizadaResponse>>.Success(actividades.ToList());
    }
}