namespace Basket.API.Models;

public class ShoppingCart
{
    public required string UserName { get; set; }

    public List<ShoppingCartItem> Items { get; set; } = [];

    public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

    // Required for mapping
    public ShoppingCart() { }

    public ShoppingCart(string userName) => UserName = userName;
}
