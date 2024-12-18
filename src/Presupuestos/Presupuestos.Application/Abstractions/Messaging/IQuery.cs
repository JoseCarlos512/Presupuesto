using MediatR;
using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Application.Abstractions.Messaging;

public interface IQuery<TResponse>: IRequest<Result<TResponse>>
{
    
}