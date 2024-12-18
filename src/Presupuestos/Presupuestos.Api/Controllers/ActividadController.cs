using Microsoft.AspNetCore.Mvc;
using Presupuestos.Application.Modules.Actividades.Queries.GetActividades;

namespace Presupuestos.Api.Controllers;

[ApiController]
public class ActividadController : BaseController
{
    [HttpGet]
    [Route("getActivities")]
    public async Task<ActionResult> GetAll(
        CancellationToken cancellationToken
    )
    {
        var query = new GetActividadesQuery();
        var _resp = await Mediator.Send(query);
        return Ok(_resp);
    }
    
    
}