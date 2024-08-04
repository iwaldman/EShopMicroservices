namespace Catalog.API.Products.DeleteProduct;

/// <summary>
/// Command to delete an existing product.
/// </summary>
/// <param name="Id">The unique identifier of the product to be deleted.</param>
public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

/// <summary>
/// Result of the delete product command.
/// </summary>
/// <param name="IsSuccessful">Indicates whether the deletion was successful.</param>
public record DeleteProductResult(bool IsSuccessful);

/// <summary>
/// Validator for the DeleteProductCommand.
/// </summary>
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteProductCommandValidator"/> class.
    /// </summary>
    public DeleteProductCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .Must(BeAValidGuid)
            .WithMessage("Id must be a valid GUID.");
    }

    /// <summary>
    /// Validates that the provided GUID is not empty.
    /// </summary>
    /// <param name="id">The GUID to validate.</param>
    /// <returns>True if the GUID is valid; otherwise, false.</returns>
    private static bool BeAValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }
}

/// <summary>
/// Handler for the DeleteProductCommand.
/// </summary>
internal class DeleteProductHandler(
    IDocumentSession documentSession,
    ILogger<DeleteProductHandler> logger
) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    /// <summary>
    /// Handles the delete product command.
    /// </summary>
    /// <param name="command">The delete product command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the delete product command.</returns>
    public async Task<DeleteProductResult> Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation("DeleteProductHandler.Handle called with {@Command}", command);

        documentSession.Delete<Product>(command.Id);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
