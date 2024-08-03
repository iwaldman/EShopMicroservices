namespace Catalog.API.Products.CreateProduct;

/// <summary>
/// Request to create a new product.
/// </summary>
/// <param name="Name">The name of the product.</param>
/// <param name="Categories">The categories of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="ImageFile">The image file name of the product.</param>
/// <param name="Price">The price of the product.</param>
public record CreateProductRequest(
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);

/// <summary>
/// Response for the created product.
/// </summary>
/// <param name="Id">The unique identifier of the created product.</param>
public record CreateProductResponse(Guid Id);

/// <summary>
/// Endpoint to handle product creation.
/// </summary>
public class CreateProductEndpoint : ICarterModule
{
    /// <summary>
    /// Adds the routes for the product creation endpoint.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/products",
            async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);

                //return Results.CreatedAtRoute(
                //    "GetProducts",
                //    new { id = response.Id },
                //    response
                //);
            }
        );
        //.WithName("GetProducts");
    }
}
