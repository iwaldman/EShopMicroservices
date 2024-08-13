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

    public override Task<CouponModel> CreateDiscount(
        CreateDiscountRequest request,
        ServerCallContext context
    )
    {
        return base.CreateDiscount(request, context);
    }

    public override Task<CouponModel> UpdateDiscount(
        UpdateDiscountRequest request,
        ServerCallContext context
    )
    {
        return base.UpdateDiscount(request, context);
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(
        DeleteDiscountRequest request,
        ServerCallContext context
    )
    {
        return base.DeleteDiscount(request, context);
    }
}
