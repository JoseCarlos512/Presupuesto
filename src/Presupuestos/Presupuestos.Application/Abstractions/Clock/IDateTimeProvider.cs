namespace Presupuestos.Application.Abstractions.Clock;

    public interface IDateTimeProvider
    {
        DateTime CurrentTime { get; }
    }
