namespace Presupuestos.Api.Routes;

public static partial class ApiRoutes
{
    public const string GetActividades = URL_BASE + "/actividad/all";
    public const string GetActividad = URL_BASE + "/actividad/{id}";
    public const string PostActividad = URL_BASE + "/actividad";
    public const string PutActividad = URL_BASE + "/actividad/{id}";
    public const string DeleteActividad = URL_BASE + "/actividad/delete/{id}";
    public const string GetActividadesEncargado = URL_BASE + "/actividad/encargado";
    public const string GetActividadesGerencia = URL_BASE + "/actividad/gerencia";
    public const string GetActividadesPresupuesto = URL_BASE + "/actividad/presupuesto";

}