using Marten.Pagination;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
    // Initializes a new instance of the <see cref="GetProductsQueryValidator"/> class.
    public GetProductsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .When(x => x.PageNumber.HasValue)
            .WithMessage("PageNumber must be greater than 0 if specified.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .When(x => x.PageSize.HasValue)
            .WithMessage("PageSize must be greater than 0 if specified.");
    }
}

internal class GetProductsQueryHandler(IDocumentSession documentSession)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(
        GetProductsQuery query,
        CancellationToken cancellationToken
    )
    {
        var products = await documentSession
            .Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return await Task.FromResult(new GetProductsResult(products));
    }
}
