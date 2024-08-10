namespace Baskets.API.Data;

public class BasketRepository(IDocumentSession documentSession) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketAsync(
        string userName,
        CancellationToken cancellationToken = default
    )
    {
        var basket = await documentSession.LoadAsync<ShoppingCart>(userName, cancellationToken);
        return basket is null ? throw new BasketNotFoundException(userName) : basket;
    }

    public async Task<ShoppingCart> StoreBasketAsync(
        ShoppingCart cart,
        CancellationToken cancellationToken = default
    )
    {
        documentSession.Store(cart);
        await documentSession.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<bool> DeleteBasketAsync(
        string userName,
        CancellationToken cancellationToken = default
    )
    {
        documentSession.Delete<ShoppingCart>(userName);
        await documentSession.SaveChangesAsync(cancellationToken);
        return true;
    }
}
