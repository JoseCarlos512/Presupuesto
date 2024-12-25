
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.Entities.Actividades.Events;

namespace Presupuestos.Domain.Tests;

public class ActividadTests
{
    [Fact]
    public void Create_ValidParameters_ReturnsNewActividad()
    {
        // Arrange
            var nombre = "Actividad de prueba";
            var fechaInicio = new DateTime(2024, 1, 1);
            var fechaFin = new DateTime(2024, 12, 31);
            var empleado = "Juan Pérez";
            string? presupuesto = "Presupuesto A";
            Guid? macroProcesoId = Guid.NewGuid();
            Guid? procesoId = Guid.NewGuid();
            Guid? subProcesoId = Guid.NewGuid();
            string? objetivo = "Objetivo de prueba";
            string? ubicacion = "Ubicación A";

            // Act
            var actividad = Actividad.Create(
                nombre, fechaInicio, fechaFin, empleado,
                presupuesto, macroProcesoId, procesoId,
                subProcesoId, objetivo, ubicacion
            );

            // Assert
            Assert.NotNull(actividad); // Verificamos que se creó la instancia
            Assert.Equal(nombre, actividad.Nombre);
            Assert.Equal(fechaInicio, actividad.FechaInicio);
            Assert.Equal(fechaFin, actividad.FechaFin);
            Assert.Equal(empleado, actividad.Empleado);
            Assert.Equal(presupuesto, actividad.Presupuesto);
            Assert.Equal(macroProcesoId, actividad.MacroProcesoId);
            Assert.Equal(procesoId, actividad.ProcesoId);
            Assert.Equal(subProcesoId, actividad.SubProcesoId);
            Assert.Equal(objetivo, actividad.Objetivo);
            Assert.Equal(ubicacion, actividad.Ubicacion);

            // Verificamos que se haya lanzado un evento de dominio
            Assert.Contains(actividad.GetDomainEvents(), e => e is ActividadCreateDomainEvent);
    }

    // [Fact]
    // public void Create_InvalidData_ThrowsException_WhenNombreAndEmpleadoAreNullAndDateRangeIsInvalid()
    // {
    //     // Arrange
    //     string? nombre = null;  // Nombre es obligatorio
    //     string? empleado = null;  // Empleado es obligatorio
    //     var fechaInicio = new DateTime(2024, 2, 1);  // Fecha de inicio posterior
    //     var fechaFin = new DateTime(2024, 1, 10);  // Fecha de fin anterior a la de inicio
    //     string? presupuesto = "Presupuesto A";
    //     Guid? macroProcesoId = Guid.NewGuid();
    //     Guid? procesoId = Guid.NewGuid();
    //     Guid? subProcesoId = Guid.NewGuid();
    //     string? objetivo = "Objetivo de prueba";
    //     string? ubicacion = "Ubicación A";

    //     // Act & Assert
    //     // Espera que le cree los objects value al proyecto
    //     // var exceptionFirst = Assert.Throws<ArgumentNullException>(() => Actividad.Create(
    //     //     nombre, fechaInicio, fechaFin, empleado,
    //     //     presupuesto, macroProcesoId, procesoId,
    //     //     subProcesoId, objetivo, ubicacion
    //     // ));

    //     // Verificamos que la excepción sea lanzada por un campo nulo
    //     //Assert.Equal("nombre", exceptionFirst.ParamName);  // Verifica que el nombre sea el parámetro problemático

    //     // Ahora para el rango de fechas
    //     nombre = "Actividad válida";
    //     empleado = "Juan Pérez";
        
    //     var exceptionSecond = Assert.Throws<InvalidOperationException>(() => Actividad.Create(
    //         nombre, fechaInicio, fechaFin, empleado,
    //         presupuesto, macroProcesoId, procesoId,
    //         subProcesoId, objetivo, ubicacion
    //     ));

    //     // Verificamos que la excepción sea lanzada por el rango de fechas
    //     Assert.Contains("fecha de inicio no puede ser posterior a la fecha de fin", exceptionSecond.Message);
    // }

    

    [Fact]
        public void Update_ValidParameters_UpdatesActividad()
        {
            // Arrange
            var actividad = Actividad.Create(
                "Actividad Original", new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),
                "Juan Pérez", "Presupuesto A", Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid(), "Objetivo A", "Ubicación A"
            );

            var nuevoNombre = "Actividad Actualizada";
            var nuevaFechaInicio = new DateTime(2024, 2, 1);
            var nuevaFechaFin = new DateTime(2024, 11, 30);
            var nuevoEmpleado = "Carlos Gómez";
            string? nuevoPresupuesto = "Presupuesto B";
            Guid? nuevoMacroProcesoId = Guid.NewGuid();
            Guid? nuevoProcesoId = Guid.NewGuid();
            Guid? nuevoSubProcesoId = Guid.NewGuid();
            string? nuevoObjetivo = "Nuevo Objetivo";
            string? nuevaUbicacion = "Nueva Ubicación";

            // Act
            actividad.Update(
                nuevoNombre, nuevaFechaInicio, nuevaFechaFin,
                nuevoEmpleado, nuevoPresupuesto, nuevoMacroProcesoId,
                nuevoProcesoId, nuevoSubProcesoId, nuevoObjetivo, nuevaUbicacion
            );

            // Assert
            Assert.Equal(nuevoNombre, actividad.Nombre);
            Assert.Equal(nuevaFechaInicio, actividad.FechaInicio);
            Assert.Equal(nuevaFechaFin, actividad.FechaFin);
            Assert.Equal(nuevoEmpleado, actividad.Empleado);
            Assert.Equal(nuevoPresupuesto, actividad.Presupuesto);
            Assert.Equal(nuevoMacroProcesoId, actividad.MacroProcesoId);
            Assert.Equal(nuevoProcesoId, actividad.ProcesoId);
            Assert.Equal(nuevoSubProcesoId, actividad.SubProcesoId);
            Assert.Equal(nuevoObjetivo, actividad.Objetivo);
            Assert.Equal(nuevaUbicacion, actividad.Ubicacion);
        }
}
