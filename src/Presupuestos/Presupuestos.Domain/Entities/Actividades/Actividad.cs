using System.ComponentModel.DataAnnotations.Schema;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Actividades.Events;
using Presupuestos.Domain.Entities.MacroProcesos;
using Presupuestos.Domain.Entities.Procesos;
using Presupuestos.Domain.Entities.SubProcesos;

namespace Presupuestos.Domain.Entities.Actividades;

public sealed class Actividad : Entity
{

    private Actividad(
         Guid id
        ,  string nombre
        , DateTime fechaInicio
        , DateTime fechaFin
        , string empleado
        , ActividadEstado estado
        , string? presupuesto
        , Guid? macroProcesoId
        , Guid? procesoId
        , Guid? subProcesoId
        , string? objetivo
        , string? ubicacion
        ) : base(id)
    {
        Nombre = nombre;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        Empleado = empleado;
        Estado = estado;
        Presupuesto = presupuesto;
        MacroProcesoId = macroProcesoId;
        ProcesoId = procesoId;
        SubProcesoId = subProcesoId;
        Objetivo = objetivo;
        Ubicacion = ubicacion;
    }

    public string Nombre { get; private set; } = null!;
    [Column(TypeName = "datetime")]
    public DateTime FechaInicio { get; private set; }
    [Column(TypeName = "datetime")]
    public DateTime FechaFin { get; private set; }
    public string Empleado { get; private set; } = null!;
    public ActividadEstado Estado { get; private set; }
    public string? Presupuesto { get; private set; }
    
    // Foreign Keys
    public Guid? MacroProcesoId { get; private set; }
    public Guid? ProcesoId { get; private set; }
    public Guid? SubProcesoId { get; private set; }
    
    // Navigation Properties
    public MacroProceso? MacroProceso { get; private set; }
    public Proceso? Proceso { get; private set; }
    public SubProceso? SubProceso { get; private set; }
    
    public string? Objetivo { get; private set; }
    public string? Ubicacion { get; private set; } = null!;

    public static Actividad Create(
          string nombre
        , DateTime fechaInicio
        , DateTime fechaFin
        , string empleado
        , string? presupuesto
        , Guid? macroProcesoId
        , Guid? procesoId
        , Guid? subProcesoId
        , string? objetivo
        , string? ubicacion
    )
    {
        var actividad = new Actividad(
            Guid.NewGuid(),
            nombre,
            fechaInicio,
            fechaFin,
            empleado,
            ActividadEstado.Activo,
            presupuesto,
            macroProcesoId,
            procesoId,
            subProcesoId,
            objetivo,
            ubicacion
        );
        
        actividad.RaiseDomainEvent(new ActividadCreateDomainEvent(actividad.Id));

        return actividad;
    }
    
    public void Update(
        string nombre,
        DateTime fechaInicio,
        DateTime fechaFin,
        string empleado,
        string? presupuesto,
        Guid? macroProcesoId,
        Guid? procesoId,
        Guid? subProcesoId,
        string? objetivo,
        string? ubicacion
    )
    {
        Nombre = nombre;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        Empleado = empleado;
        Presupuesto = presupuesto;
        MacroProcesoId = macroProcesoId;
        ProcesoId = procesoId;
        SubProcesoId = subProcesoId;
        Objetivo = objetivo;
        Ubicacion = ubicacion;
    }

}