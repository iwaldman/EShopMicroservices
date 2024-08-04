﻿namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryHandler(
    IDocumentSession documentSession,
    ILogger<GetProductByCategoryHandler> logger
) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(
        GetProductByCategoryQuery query,
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation("GetProductByCategoryHandler.Handle called with {@Query}", query);

        var products = await documentSession
            .Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync(token: cancellationToken);

        return new GetProductByCategoryResult(products!);
    }
}