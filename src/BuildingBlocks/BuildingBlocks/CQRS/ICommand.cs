using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// Marker interface for a command with a void response.
/// </summary>
public interface ICommand : ICommand<Unit> { }

/// <summary>
/// Interface for a command with a specific response type.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse> { }
