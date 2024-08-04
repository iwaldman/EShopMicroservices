namespace BuildingBlocks.Exceptions;

/// <summary>
/// Exception thrown when an internal server error occurs.
/// </summary>
public class InternalServerException : Exception
{
    /// <summary>
    /// Gets the details of the internal server error.
    /// </summary>
    public string? Details { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InternalServerException(string message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a specified error message and details.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="details">The details of the error.</param>
    public InternalServerException(string message, string details)
        : base(message)
    {
        Details = details;
    }
}
