using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null.");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required.");
    }
}

internal class StoreBasketCommandHandler(
    IBasketRepository basketRepository,
    DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient
) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(
        StoreBasketCommand command,
        CancellationToken cancellationToken
    )
    {
        await DeductDiscount(discountProtoServiceClient, command, cancellationToken);

        await basketRepository.StoreBasketAsync(command.Cart, cancellationToken);

        // TODO: update cache

        return new StoreBasketResult(command.Cart.UserName);
    }

    private static async Task DeductDiscount(
        DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient,
        StoreBasketCommand command,
        CancellationToken cancellationToken
    )
    {
        var discountTasks = command.Cart.Items.Select(async item =>
        {
            var coupon = await discountProtoServiceClient.GetDiscountAsync(
                new GetDiscountRequest { ProductName = item.ProductName },
                cancellationToken: cancellationToken
            );

            item.Price -= coupon.Amount;
        });

        await Task.WhenAll(discountTasks);
    }
}
