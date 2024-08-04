namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccessful);

internal class DeleteProductHandler(
    IDocumentSession documentSession,
    ILogger<DeleteProductHandler> logger
) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
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
