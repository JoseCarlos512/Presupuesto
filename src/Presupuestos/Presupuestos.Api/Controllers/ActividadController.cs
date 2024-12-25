using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presupuestos.Api.Controllers.Request;
using Presupuestos.Api.Routes;
using Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;
using Presupuestos.Application.Modules.Actividades.Queries.GetActividades;
using Presupuestos.Application.Modules.Actividades.Commands.ActualizarActividad;
using Presupuestos.Application.Modules.Actividades.Commands.EliminarActividad;
using Presupuestos.Application.Modules.Actividades.Queries.GetActividad;
using Presupuestos.Application.Modules.Actividades.Queries.GetActividadesEncargado;
using Presupuestos.Application.Modules.Actividades.Queries.GetActividadesGerencia;
using Presupuestos.Application.Modules.Actividades.Queries.GetActividadesPresupuesto;

namespace Presupuestos.Api.Controllers;

[ApiController]
public class ActividadController : BaseController
{
    public ActividadController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [Route(ApiRoutes.GetActividades)]
    public async Task<ActionResult> GetActividades(
        CancellationToken cancellationToken
    )
    {
        string Usercode = "jleon";
        var query = new GetActividadesQuery(Usercode);
        var _resp = await Mediator.Send(query, cancellationToken);
        return Ok(_resp);
    }
    
    [HttpGet]
    [Route(ApiRoutes.GetActividad)]
    public async Task<ActionResult> GetActividad(
        Guid id,
        CancellationToken cancellationToken
    ) 
    {
        var query = new GetActividadQuery(id);
        var _resp = await Mediator.Send(query, cancellationToken);
        return _resp.IsSuccess ? Ok(_resp) : NotFound();
    }
    
    [HttpPost]
    [Route(ApiRoutes.PostActividad)]
    public async Task<IActionResult> PostActividad(
        ActividadRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearActividadCommand
        (
            request.nombre,
            request.fecha_inicio,  
            request.fecha_fin,
            request.empleado,
            request.presupuesto,
            request.id_macro_proceso, 
            request.id_proceso,
            request.id_subproceso,  
            request.objetivo,
            request.ubicacion
        );

        var resultado = await Mediator.Send(command,cancellationToken);

        if (resultado.IsSuccess)
        {
            return CreatedAtAction(nameof(GetActividad), new { id = resultado.Value } , resultado.Value );
        }
        return BadRequest(resultado.Error);
    }
    
    [HttpPut]
    [Route(ApiRoutes.PutActividad)]
    public async Task<IActionResult> PutActividad(
        Guid id,
        ActividadRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new ActualizarActividadCommand
        (
            id,
            request.nombre,
            request.fecha_inicio,  
            request.fecha_fin,
            request.empleado,
            request.presupuesto,
            request.id_macro_proceso, 
            request.id_proceso,
            request.id_subproceso,  
            request.objetivo,
            request.ubicacion
        );

        var resultado = await Mediator.Send(command,cancellationToken);

        if (resultado.IsSuccess)
        {
            return NoContent();
        }
        return BadRequest(resultado.Error);
    }

    [HttpDelete]
    [Route(ApiRoutes.DeleteActividad)]
    public async Task<IActionResult> DeleteActividad(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new EliminarActividadCommand(id);
        var resultado = await Mediator.Send(command, cancellationToken);
        if (resultado.IsSuccess)
        {
            return NoContent();
        }
        return BadRequest(resultado.Error);
    }
    
    [HttpGet]
    [Route(ApiRoutes.GetActividadesEncargado)]
    public async Task<ActionResult> GetActividadesEncargado(
        CancellationToken cancellationToken
    )
    {
        string Usercode = "jleon";
        var query = new GetActividadesEncargadoQuery(Usercode);
        var _resp = await Mediator.Send(query);
        return Ok(_resp);
    }
    
    [HttpGet]
    [Route(ApiRoutes.GetActividadesGerencia)]
    public async Task<ActionResult> GetActividadesGerencia(
        CancellationToken cancellationToken
    ) 
    {
        string Usercode = "jleon";
        var query = new GetActividadesGerenciaQuery(Usercode);
        var _resp = await Mediator.Send(query);
        return Ok(_resp);
    }
    
    [HttpGet]
    [Route(ApiRoutes.GetActividadesPresupuesto)]
    public async Task<ActionResult> GetActividadesPresupuesto(
        CancellationToken cancellationToken
    ) 
    {
        string Usercode = "jleon";
        var query = new GetActividadesPresupuestoQuery(Usercode);
        var _resp = await Mediator.Send(query);
        return Ok(_resp);
    }
    
    
}