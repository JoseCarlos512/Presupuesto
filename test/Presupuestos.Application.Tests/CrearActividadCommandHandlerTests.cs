using Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;
using Presupuestos.Domain.Abstractions;
using FluentAssertions;
using Moq;
using Presupuestos.Domain.IRepository;

namespace Presupuestos.Application.Tests;

public class CrearActividadCommandHandlerTests
{
    [Fact]
    public async void Handle_ShouldCreateActividad_WhenAllEntitiesExist()
    {
        // Arrange
        var mockActividadRepository = new Mock<IActividadRepository>();
        var mockMacroProcesoRepository = new Mock<IMacroProcesoRepository>();
        var mockProcesoRepository = new Mock<IProcesoRepository>();
        var mockSubProcesoRepository = new Mock<ISubProcesoRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        
        var handler = new CrearActividadCommandHandler(
            mockActividadRepository.Object,
            mockMacroProcesoRepository.Object,
            mockProcesoRepository.Object,
            mockSubProcesoRepository.Object,
            mockUnitOfWork.Object
        );
        
        var command = new CrearActividadCommand
         (
             "Nueva Actividad",
             DateTime.UtcNow,
             DateTime.UtcNow.AddDays(5),
             "Empleado Test",
             "1000",
             Guid.NewGuid(),
             Guid.NewGuid(),
             Guid.NewGuid(),
             "Completar tarea",
             "Oficina"
         );
        
        var result = await handler.Handle(command,CancellationToken.None);

        result.Should().BeOfType<Result<Guid>>();
    }
}