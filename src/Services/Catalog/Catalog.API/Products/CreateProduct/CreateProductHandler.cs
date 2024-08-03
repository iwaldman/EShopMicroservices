using Catalog.API.Models;

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
/// Handler for the CreateProductCommand.
/// </summary>
internal class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    /// <summary>
    /// Handles the CreateProductCommand.
    /// </summary>
    /// <param name="command">The command to create a product.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the CreateProductResult.</returns>
    public Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken
    )
    {
        // create a product entity from the command

        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            Price = command.Price,
            ImageFile = command.ImageFile
        };

        // save the product entity to the database

        // return the product entity's id
        return Task.FromResult(new CreateProductResult(Guid.NewGuid()));
    }
}
