namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageFile
) : ICommand<UpdateProductResult> { }

public record UpdateProductResult(bool IsSuccessful);

internal class UpdateProductCommandHandler(
    IDocumentSession documentSession,
    ILogger<UpdateProductCommandHandler> logger
) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(
        UpdateProductCommand command,
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

        var product = await documentSession.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            logger.LogWarning("Product with ID {Id} was not found", command.Id);
            throw new ProductNotFoundException();
        }

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
