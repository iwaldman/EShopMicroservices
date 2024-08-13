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



//public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
//{
//    private readonly IDiscountRepository _repository;
//    private readonly ILogger<DiscountService> _logger;
//    private readonly IMapper _mapper;

//    public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
//    {
//        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//    }

//    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
//    {
//        var coupon = await _repository.GetDiscount(request.ProductName);
//        if (coupon == null)
//        {
//            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
//        }

//        _logger.LogInformation("Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);

//        var couponModel = _mapper.Map<CouponModel>(coupon);
//        return couponModel;
//    }

//    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
//    {
//        var coupon = _mapper.Map<Coupon>(request.Coupon);
//        await _repository.CreateDiscount(coupon);
//        _logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

//        var couponModel = _mapper.Map<CouponModel>(coupon);
//        return couponModel;
//    }

//    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
//    {
//        var coupon = _mapper.Map<Coupon>(request.Coupon);
//        await _repository.UpdateDiscount(coupon);
//        _logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);

//        var couponModel = _mapper.Map<CouponModel>(coupon);
//        return couponModel;
//    }

//    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
//    {
//        var deleted = await _repository.DeleteDiscount(request.ProductName);
//        var response = new DeleteDiscountResponse
//        {
//            Success = deleted
//        };

//        return response;
//    }
//}
