using System.ComponentModel.DataAnnotations.Schema;

namespace Presupuestos.Application.Modules.Actividades.Response;

public class ActividadResponse
{
    public int actividad { get; set; }
    public string nombre { get; set; } = null!;
    [Column(TypeName = "datetime")]
    public DateTime fecha_inicio { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime fecha_fin { get; set; }
    public string? nombre_empleado { get; set; } = null!;
    public string empleado { get; set; } = null!;
    public string? nombre_ubicacion { get; set; } = null!;
    public string? ubicacion { get; set; } = null!;
    public int estado { get; set; }
    public string? nombre_presupuesto { get; set; } = null!;
    public string? presupuesto { get; set; } = null!;
    public int? macro_proceso { get; set; }
    public string? nombre_macro_proceso { get; set; } = null!;
    public int? proceso { get; set; }
    public string? nombre_proceso { get; set; } = null;
    public int? subproceso { get; set; } = null;
    public string? nombre_subproceso { get; set; } = null;
    public string? objetivo { get; set; }
}