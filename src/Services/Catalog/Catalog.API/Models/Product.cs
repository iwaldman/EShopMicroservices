namespace Catalog.API.Models;

/// <summary>
/// Represents a product in the catalog.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the image file name of the product.
    /// </summary>
    public required string ImageFile { get; set; }

    /// <summary>
    /// Gets or sets the categories of the product.
    /// </summary>
    public List<string> Categories { get; set; } = [];
}
