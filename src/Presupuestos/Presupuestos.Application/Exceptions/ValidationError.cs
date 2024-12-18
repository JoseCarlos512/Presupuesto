namespace Presupuestos.Application.Exceptions;

public record ValidationError(
    string PropertyName,
    string ErrorMessage
);