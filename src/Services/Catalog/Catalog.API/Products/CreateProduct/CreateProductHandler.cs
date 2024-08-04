namespace Catalog.API.Products.CreateProduct;

/// <summary>
/// Command to create a new product.
/// </summary>
/// <param name="Name">The name of the product.</param>
/// <param name="Categories">The categories of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="Price">The price of the product.</param>
/// <param name="ImageFile">The image file name of the product.</param>
public record CreateProductCommand(
    string Name,
    List<string> Categories,
    string Description,
    decimal Price,
    string ImageFile
) : ICommand<CreateProductResult>;

/// <summary>
/// Result of the CreateProductCommand.
/// </summary>
/// <param name="Id">The unique identifier of the created product.</param>
public record CreateProductResult(Guid Id);

/// <summary>
/// Validator for the CreateProductCommand.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    // Initializes a new instance of the <see cref="CreateProductCommandValidator"/> class.
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Categories are required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image file is required.");
    }
}

/// <summary>
/// Handler for the CreateProductCommand.
/// </summary>
internal class CreateProductCommandHandler(
    IDocumentSession documentSession,
    ILogger<CreateProductCommandHandler> logger
) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    /// <summary>
    /// Handles the CreateProductCommand.
    /// </summary>
    /// <param name="command">The command to create a product.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the CreateProductResult.</returns>
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);

        // Creates a new product instance from the command parameters.
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            Price = command.Price,
            ImageFile = command.ImageFile
        };

        // Stores the product in the document session.
        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        // Returns the result of the command with the product's unique identifier.
        return await Task.FromResult(new CreateProductResult(product.Id));
    }
}
