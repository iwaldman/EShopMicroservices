namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext discountContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(
        GetDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon = await discountContext.Coupons.FirstOrDefaultAsync(
            c => c.ProductName == request.ProductName
        );

        coupon ??= new Coupon
        {
            ProductName = "No Discount",
            Amount = 0,
            Description = "No Discount Description"
        };

        var couponModel = coupon.Adapt<CouponModel>();

        logger.LogInformation(
            "Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}",
            coupon.ProductName,
            coupon.Amount
        );

        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(
        CreateDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon =
            request.Adapt<Coupon>()
            ?? throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid request object.")
            );

        discountContext.Coupons.Add(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully created. ProductName : {ProductName}",
            coupon.ProductName
        );

        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(
        UpdateDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon =
            request.Adapt<Coupon>()
            ?? throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid request object.")
            );

        discountContext.Coupons.Update(coupon);

        await discountContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully updated. ProductName : {ProductName}",
            coupon.ProductName
        );

        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(
        DeleteDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon =
            await discountContext.Coupons.FirstOrDefaultAsync(
                c => c.ProductName == request.ProductName
            )
            ?? throw new RpcException(
                new Status(
                    StatusCode.NotFound,
                    $"Discount with ProductName={request.ProductName} not found."
                )
            );

        discountContext.Coupons.Remove(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully deleted. ProductName : {ProductName}",
            coupon.ProductName
        );

        return new DeleteDiscountResponse { Success = true };
    }
}
