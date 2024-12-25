
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Moq;
using Presupuestos.Application.Abstractions.Behaviors;
using Presupuestos.Application.Abstractions.Messaging;
using Presupuestos.Application.Exceptions;

namespace Presupuestos.Application.Tests;
public class ValidationBehaviorTests
{
        [Fact]
    public async void Handle_Should_Not_Throw_When_Validation_Succeds()
    {
        var validatorMock = new Mock<IValidator<IBaseCommand>>();

        validatorMock.Setup(v => v.Validate(It.IsAny<ValidationContext<IBaseCommand>>()))
            .Returns(new FluentValidation.Results.ValidationResult());
        
        var validatorBehavior = new ValidationBehavior<IBaseCommand, Unit>([validatorMock.Object]);

        var commandMock = new Mock<IBaseCommand>();

        var requestHandlerDelegateMock = new Mock<RequestHandlerDelegate<Unit>>();

        var result = await validatorBehavior.Handle(commandMock.Object,requestHandlerDelegateMock.Object, CancellationToken.None);

        Assert.Equal(Unit.Value,result);
    }

     [Fact]
    public async void Handle_Should_Throw_ValidationException_When_Validation_Fails()
    {
        var validatorMock = new Mock<IValidator<IBaseCommand>>();

        validatorMock.Setup(v => v.Validate(It.IsAny<ValidationContext<IBaseCommand>>()))
            .Returns(new FluentValidation.Results.ValidationResult(new [] { new ValidationFailure( "Property","Error" ) }));
        
        var validatorBehavior = new ValidationBehavior<IBaseCommand, Unit>([validatorMock.Object]);

        var commandMock = new Mock<IBaseCommand>();

        var requestHandlerDelegateMock = new Mock<RequestHandlerDelegate<Unit>>();

        await Assert.ThrowsAsync<ValidationExceptions>(
            () => validatorBehavior.Handle(
                commandMock.Object,
                requestHandlerDelegateMock.Object,
                CancellationToken.None
            )
        );
    }
}