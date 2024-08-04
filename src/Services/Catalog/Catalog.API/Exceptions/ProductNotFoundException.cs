namespace Catalog.API.Exceptions;

/// <summary>
/// Exception thrown when a product with the specified ID is not found.
/// </summary>
public class ProductNotFoundException(Guid id) : NotFoundException("Product", id) { }
