using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct;

/// <summary>
/// Command to update an existing product.
/// </summary>
/// <param name="Id">The unique identifier of the product.</param>
/// <param name="Name">The name of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="Categories">The categories of the product.</param>
/// <param name="Price">The price of the product.</param>
/// <param name="ImageFile">The image file name of the product.</param>
public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageFile
) : ICommand<UpdateProductResult> { }

/// <summary>
/// Result of the update product command.
/// </summary>
/// <param name="IsSuccessful">Indicates whether the update was successful.</param>
public record UpdateProductResult(bool IsSuccessful);

/// <summary>
/// Validator for the UpdateProductCommand.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductCommandValidator"/> class.
    /// </summary>
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .Must(BeAValidGuid)
            .WithMessage("Id must be a valid GUID.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 150)
            .WithMessage("Name must be between 2 and 150 characters.");

        RuleFor(x => x.Categories).NotEmpty().WithMessage("Categories are required.");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");

        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image file is required.");
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
/// Handler for the UpdateProductCommand.
/// </summary>
internal class UpdateProductCommandHandler(IDocumentSession documentSession)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    /// <summary>
    /// Handles the update product command.
    /// </summary>
    /// <param name="command">The update product command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the update product command.</returns>
    public async Task<UpdateProductResult> Handle(
        UpdateProductCommand command,
        CancellationToken cancellationToken
    )
    {
        var product =
            await documentSession.LoadAsync<Product>(command.Id, cancellationToken)
            ?? throw new ProductNotFoundException(command.Id);

        product.Name = command.Name;
        product.Description = command.Description;
        product.Categories = command.Categories;
        product.Price = command.Price;
        product.ImageFile = command.ImageFile;

        documentSession.Update(product);

        await documentSession.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
