namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<Product> Products);

public class GetProductsByCategoryQueryValidator : AbstractValidator<GetProductsByCategoryQuery>
{
    public GetProductsByCategoryQueryValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
    }
}

internal class GetProductsByCategoryHandler(IDocumentSession documentSession)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(
        GetProductsByCategoryQuery query,
        CancellationToken cancellationToken
    )
    {
        var products = await documentSession
            .Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync(token: cancellationToken);

        return new GetProductsByCategoryResult(products!);
    }
}
