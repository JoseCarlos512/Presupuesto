using Presupuestos.Application.Abstractions.Clock;

namespace Presupuestos.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}