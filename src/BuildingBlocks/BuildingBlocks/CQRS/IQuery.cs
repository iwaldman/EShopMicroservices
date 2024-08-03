using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// Interface for a query with a specific response type.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull { }
