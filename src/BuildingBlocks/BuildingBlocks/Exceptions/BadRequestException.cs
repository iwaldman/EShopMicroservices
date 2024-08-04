namespace BuildingBlocks.Exceptions;

/// <summary>
/// Exception that represents a bad request error.
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public BadRequestException(string message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message and details.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="details">The details that provide additional information about the error.</param>
    public BadRequestException(string message, string details)
        : base(message)
    {
        Details = details;
    }

    /// <summary>
    /// Gets the details that provide additional information about the error.
    /// </summary>
    public string? Details { get; }
}
