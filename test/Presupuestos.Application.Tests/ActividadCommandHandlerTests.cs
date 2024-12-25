
using Presupuestos.Application.Modules.Actividades.Commands.CrearActividad;
using Presupuestos.Domain.Abstractions;
using Presupuestos.Domain.Entities.Actividades;
using Presupuestos.Domain.IRepository;
using FluentAssertions;
using Moq;
using Presupuestos.Domain.Entities.MacroProcesos;
using Presupuestos.Domain.Entities.Procesos;
using Presupuestos.Domain.Entities.SubProcesos;

namespace Presupuestos.Application.Tests
{
     public class ActividadCommandHandlerTests
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

            var macroProceso = new MacroProceso(Guid.NewGuid(), "MacroProceso Test");
            var proceso = new Proceso(Guid.NewGuid(), "Proceso Test", macroProceso.Id);
            var subProceso = new SubProceso(Guid.NewGuid(), "SubProceso Test", proceso.Id);
            
            mockMacroProcesoRepository
                .Setup(repo => repo.GetByIdAsync(macroProceso.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(macroProceso);

            mockProcesoRepository
                .Setup(repo => repo.GetByIdAsync(proceso.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(proceso);

            mockSubProcesoRepository
                .Setup(repo => repo.GetByIdAsync(subProceso.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(subProceso);
            
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

            

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.IsType<Guid>(result.Value);

            mockMacroProcesoRepository.Verify(repo => repo.GetByIdAsync(command.id_macro_proceso, It.IsAny<CancellationToken>()), Times.Once);
            mockProcesoRepository.Verify(repo => repo.GetByIdAsync(command.id_proceso, It.IsAny<CancellationToken>()), Times.Once);
            mockSubProcesoRepository.Verify(repo => repo.GetByIdAsync(command.id_subproceso, It.IsAny<CancellationToken>()), Times.Once);
            mockActividadRepository.Verify(repo => repo.Add(It.IsAny<Actividad>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        // [Fact]
        // public async Task Handle_ShouldReturnFailure_WhenMacroProcesoNotFound()
        // {
        //     // Arrange
        //     var mockMacroProcesoRepository = new Mock<IMacroProcesoRepository>();
        //     var mockProcesoRepository = new Mock<IProcesoRepository>();
        //     var mockSubProcesoRepository = new Mock<ISubProcesoRepository>();
        //     var mockActividadRepository = new Mock<IActividadRepository>();
        //     var mockUnitOfWork = new Mock<IUnitOfWork>();

        //     mockMacroProcesoRepository
        //         .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
        //         .ReturnsAsync((MacroProceso)null);

        //     var command = new CrearActividadCommand
        //     {
        //         id_macro_proceso = Guid.NewGuid(),
        //         id_proceso = Guid.NewGuid(),
        //         id_subproceso = Guid.NewGuid(),
        //         nombre = "Nueva Actividad",
        //         fecha_inicio = DateTime.UtcNow,
        //         fecha_fin = DateTime.UtcNow.AddDays(5),
        //         empleado = "Empleado Test",
        //         presupuesto = "1000",
        //         objetivo = "Completar tarea",
        //         ubicacion = "Oficina"
        //     };

        //     var handler = new CrearActividadCommandHandler(
        //         mockActividadRepository.Object,
        //         mockMacroProcesoRepository.Object,
        //         mockProcesoRepository.Object,
        //         mockSubProcesoRepository.Object,
        //         mockUnitOfWork.Object
        //     );

        //     // Act
        //     var result = await handler.Handle(command, CancellationToken.None);

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.False(result.IsSuccess);
        //     Assert.Equal(MacroProcesoErrors.NotFound, result.Error);

        //     mockMacroProcesoRepository.Verify(repo => repo.GetByIdAsync(command.id_macro_proceso, It.IsAny<CancellationToken>()), Times.Once);
        //     mockProcesoRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never);
        //     mockSubProcesoRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never);
        //     mockActividadRepository.Verify(repo => repo.Add(It.IsAny<Actividad>()), Times.Never);
        //     mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        // }
    }   
}